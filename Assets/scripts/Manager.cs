using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public AudioSource music;

    public bool playMusic;

    public ArrowScroller arrows;

    public static Manager instance;

    public int currentScore;
    public int normalHitScore = 100;
    public int goodHitScore = 125;
    public int perfectHitScore = 150;

    public int currentMultiplier;
    public int multiplierCounter;
    public int[] multiplierLevels;

    public int currentCombo;

    public Text scoreText;
    public Text multiText;
    public Text comboText;
    public Text beginText;

    public float totalNotes;
    public float normalHits;
    public float goodHits;
    public float perfectHits;
    public float missedHits;

    public GameObject resultsWindow;
    public Text percentHitText, normalsText, goodsText, perfectsText, missesText, rankText, finalScoreText;

    void Start()
    {
        instance = this;

        scoreText.text = "Score: 0";
        currentMultiplier = 1;
        currentCombo = 0;
        totalNotes = FindObjectsOfType<NoteObject>().Length;
    }

    void Update()
    {
        if (!playMusic)
        {
            if (Input.anyKeyDown)
            {
                playMusic = true;
                arrows.started = true;

                music.Play();
                Destroy(beginText);
            }
        }
        else
        {
            if (!music.isPlaying && !resultsWindow.activeInHierarchy)
            {
                resultsWindow.SetActive(true);
                normalsText.text = normalHits.ToString();
                goodsText.text = goodHits.ToString();
                perfectsText.text = perfectHits.ToString();
                missesText.text = missedHits.ToString();

                float totalHits = normalHits + goodHits + perfectHits;
                float percentHit = (totalHits / totalNotes) * 100.0f;
                percentHitText.text = percentHit.ToString("F1") + "%";

                string rankVal = "F";
                if (percentHit > 40)
                {
                    rankVal = "D";
                    if (percentHit > 55)
                    {
                        rankVal = "C";
                        if (percentHit > 70)
                        {
                            rankVal = "B";
                            if (percentHit > 85)
                            {
                                rankVal = "A";
                                if (percentHit > 95)
                                {
                                    rankVal = "S";
                                }
                            }
                        }
                    }
                }

                rankText.text = rankVal;

                finalScoreText.text = currentScore.ToString();
            }
        }
    }

    public void NoteHit()
    {
        Debug.Log("Hit on Time");

        if (currentMultiplier - 1 < multiplierLevels.Length)
        {
            multiplierCounter++;

            if (multiplierLevels[currentMultiplier - 1] <= multiplierCounter)
            {
                multiplierCounter = 0;
                currentMultiplier++;
            }
        }

        currentCombo++;
        comboText.text = currentCombo.ToString();
        multiText.text = "Multiplier: x" + currentMultiplier;
        scoreText.text = "Score: " + currentScore;
    }

    public void NoteMiss()
    {
        Debug.Log("Missed Note");

        currentMultiplier = 1;
        multiplierCounter = 0;
        currentCombo = 0;
        multiText.text = "Multiplier: x" + currentMultiplier;
        comboText.text = currentCombo.ToString();

        missedHits++;
    }

    public void NormalHit()
    {
        currentScore += normalHitScore * currentMultiplier;
        NoteHit();

        normalHits++;
    }

    public void GoodHit()
    {
        currentScore += goodHitScore * currentMultiplier;
        NoteHit();

        goodHits++;
    }

    public void PerfectHit()
    {
        currentScore += perfectHitScore * currentMultiplier;
        NoteHit();

        perfectHits++;
    }
}
