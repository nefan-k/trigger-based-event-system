using System.Collections.Generic;
using UnityEngine;

// Written by Steve Streeting 2017
// License: CC0 Public Domain http://creativecommons.org/publicdomain/zero/1.0/

// Modifications par Aleksandr Kudashkin

public class Flickering : MonoBehaviour
{
    public new Light light;
    public float minIntensity = 0f;
    public float maxIntensity = 1f;
    [Range(1, 50)] public int smoothing = 5;

    // Queue of random values
    Queue<float> smoothQueue;
    float lastSum = 0;
    float nextAverage = 0;

    float timeProgress = 0;
    float progress = 0;

    public void ResetQueue()
    {
        smoothQueue.Clear();
        lastSum = 0;
    }

    void Start()
    {
        smoothQueue = new Queue<float>(smoothing);
        if (light == null)
            light = GetComponent<Light>();
    }

    void Update()
    {
        if(light == null)
            return;

        if(timeProgress > 1)
        {
            timeProgress = 0;
            nextAverage = GenerateIntensity();
        }
        else
        {
            progress = Mathf.Sin(timeProgress * Mathf.PI / 2);
            light.intensity = Mathf.Lerp(light.intensity, nextAverage, progress);
            timeProgress += 1f/smoothing;
        }
    }


    float GenerateIntensity()
    {
        while (smoothQueue.Count >= smoothing)
            lastSum -= smoothQueue.Dequeue();

        float newVal = Random.Range(minIntensity, maxIntensity);
        smoothQueue.Enqueue(newVal);
        lastSum += newVal;

        return lastSum / (float)smoothQueue.Count;
    }

}