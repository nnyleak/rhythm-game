using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectObject : MonoBehaviour
{
    public float lifetime = 1.0f;
    public float fadeSpeed;

    void Update()
    {
        Color objectColor = this.GetComponent<Renderer>().material.color;
        float fadeAmt = objectColor.a - (fadeSpeed * Time.deltaTime);

        objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmt);
        this.GetComponent<Renderer>().material.color = objectColor;

        Destroy(gameObject, lifetime);
    }
}
