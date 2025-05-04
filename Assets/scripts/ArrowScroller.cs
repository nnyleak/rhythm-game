using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScroller : MonoBehaviour
{
    public float tempo;
    public bool started;

    void Start()
    {
        tempo = tempo / 60;
    }

    void Update()
    {
        if (started)
        {
            transform.position -= new Vector3(0.0f, tempo * Time.deltaTime, 0.0f);
        }
    }
}
