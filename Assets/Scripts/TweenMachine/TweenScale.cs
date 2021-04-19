using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TweenScale : Tween
{
    private Vector3 _targetScale;
    protected Vector3 _direction;

    protected override void PerformTween(float easeStep)
    {
        _gameObject.transform.localScale =  _targetScale * easeStep;
    }
    protected override void OnTweenComplete()
    {
        base.OnTweenComplete();
        _gameObject.transform.localScale = _targetScale;
    }

    protected override void OnTweenStart()
    {
        base.OnTweenStart();
    }

    public TweenScale(GameObject objectToMove, Vector3 targetScale, float speed, Func<float, float> easeMethod, Action OnComplete, Action OnTweenStart) : base(objectToMove, speed, easeMethod)
    {
        _targetScale = targetScale;
        OnTweenCompleteAction += OnComplete;
        OnTweenStartAction += OnTweenStart;
    }
}