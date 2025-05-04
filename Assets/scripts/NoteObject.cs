using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;

    public KeyCode key;

    public GameObject hitFX, goodFX, perfectFX, missFX;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);

                //Manager.instance.NoteHit();
                if (Mathf.Abs(transform.position.y) > 0.25)
                {
                    Debug.Log("hit");
                    Manager.instance.NormalHit();
                    Instantiate(hitFX, hitFX.transform.position, hitFX.transform.rotation);
                }
                else if (Mathf.Abs(transform.position.y) > 0.05f)
                {
                    Debug.Log("good hit");
                    Manager.instance.GoodHit();
                    Instantiate(goodFX, goodFX.transform.position, goodFX.transform.rotation);
                }
                else
                {
                    Debug.Log("perfect hit");
                    Manager.instance.PerfectHit();
                    Instantiate(perfectFX, perfectFX.transform.position, perfectFX.transform.rotation);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator" && gameObject.activeSelf)
        {
            canBePressed = false;

            Manager.instance.NoteMiss();
            Instantiate(missFX, missFX.transform.position, missFX.transform.rotation);
        }
    }
}
