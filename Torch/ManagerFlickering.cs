using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerFlickering : MonoBehaviour
{
    public Flickering flickering;
    public Transform flame;
    public AnimationCurve evolution;

    public float duration;
    private float _currentTime;
    [HideInInspector] public bool isOver { get; private set; }

    private float _normIntensity;
    private int _normSmoothness;

    private float _diffIntensity;
    public int diffSmoothness;

    private Vector3 _normFlame;
    public float minFlameScale;

    void Start()
    {
        if(flickering == null)
            flickering = GetComponent<Flickering>();

        _normIntensity = flickering.maxIntensity;
        _normSmoothness = flickering.smoothing;

        _diffIntensity = flickering.maxIntensity - flickering.minIntensity;

        if(flame != null)
            _normFlame = flame.localScale;
    }

    void Update()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime > duration)
        {
            isOver = true;
            _currentTime = duration;
        }

        float timeRatio = _currentTime / duration;
        flickering.maxIntensity = _normIntensity - _diffIntensity * evolution.Evaluate(timeRatio);
        flickering.smoothing = _normSmoothness - (int)(diffSmoothness * evolution.Evaluate(timeRatio));

        flame.localScale = Vector3.Lerp(_normFlame, _normFlame * minFlameScale, timeRatio);
    }

    public void ResetTimer()
    {
        _currentTime = 0;

        flickering.maxIntensity = _normIntensity;
        flickering.smoothing = _normSmoothness;

        flame.localScale = _normFlame;
    }
}