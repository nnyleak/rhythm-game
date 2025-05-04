using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite defaultButton;
    public Sprite pressedButton;

    public KeyCode key;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            spriteRenderer.sprite = pressedButton;
        }

        if (Input.GetKeyUp(key))
        {
            spriteRenderer.sprite = defaultButton;
        }
    }
}
