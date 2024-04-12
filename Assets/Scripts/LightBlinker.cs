using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBlinker : MonoBehaviour
{
    [Range(0f, 10f)]
    [SerializeField] float blinkedTimer = 1f;
    [Range(0.01f, 1f)]
    [SerializeField] float blinkedInterval = 0.5f;
    [SerializeField] int blinkedCounter = 1;

    bool isBlinked;
    float timer = 0;

    Light lightComponent;

    // Start is called before the first frame update
    void Start()
    {
        timer = blinkedInterval;
        lightComponent = GetComponent<Light>();
        StartCoroutine(Blink());
    }

    // Update is called once per frame
    void Update()
    {
        if (!isBlinked && timer >= blinkedTimer)
        {
            isBlinked = true;
            StartCoroutine(Blink());
        } else {
            timer += 1 * Time.deltaTime;
        }
    }

    IEnumerator Blink()
    {
        for (int i = 0; i < blinkedCounter; i++)
        {
            lightComponent.enabled = false;
            yield return new WaitForSeconds(blinkedInterval);
            lightComponent.enabled = true;
            yield return new WaitForSeconds(blinkedInterval);
        }
        isBlinked = false;
        timer = 0;
    }
}
