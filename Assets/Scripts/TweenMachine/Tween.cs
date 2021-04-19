using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Tween
{
    protected GameObject _gameObject;
    protected Vector3 _startPosition;

    private float _speed;
    private float _percent;

    private Func<float, float> EaseMethod;

    private bool isFinished = false;
    
    public Tween(GameObject objectToMove, float speed, Func<float, float> easeMethod)
    {
        _gameObject = objectToMove;
        _speed = speed;

        _startPosition = _gameObject.transform.position;
        _percent = 0;

        EaseMethod = easeMethod;
        
        Debug.Log("Tween Started");
    }
    public void UpdateTween(float dt)
    {
        _percent += dt / _speed;

        if (_percent < 1)
        {
            float easeStep = EaseMethod(_percent);
            //_gameObject.transform.position = _startPosition + (_direction * easeStep);
            PerformTween(easeStep);
            Debug.Log(_gameObject + ": Tween Update");
        }
        else
        {
            OnTweenComplete();
            isFinished = true;
            Debug.Log("Tween Finished!");

        }
    }

    protected virtual void PerformTween(float easeStep)
    {

    }

    protected virtual void OnTweenComplete()
    {

    }

    public bool IsFinished()
    {
        return isFinished;
    }
}
