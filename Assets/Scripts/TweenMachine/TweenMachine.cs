using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenMachine : MonoBehaviour
{
    private static TweenMachine instance;
    private List<Tween> _activeTweens = new List<Tween>();
    private Dictionary<EaseTypes, Func<float, float>> easingCombiner = new Dictionary<EaseTypes, Func<float, float>>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            this.enabled = false;
            Debug.LogWarning("there may only be one object with the tweenmachine class");
            return;
        }

        easingCombiner.Add(EaseTypes.easeInSine, Easings.EaseInSine);
        easingCombiner.Add(EaseTypes.easeOutSine, Easings.EaseOutSine);
        easingCombiner.Add(EaseTypes.easeInOutSine, Easings.EaseInOutSine);

        easingCombiner.Add(EaseTypes.easeInCubic, Easings.EaseInCubic);
        easingCombiner.Add(EaseTypes.easeOutCubic, Easings.EaseOutCubic);
        easingCombiner.Add(EaseTypes.easeInOutCubic, Easings.EaseInOutCubic);

        easingCombiner.Add(EaseTypes.easeInQuint, Easings.EaseInQuint);
        easingCombiner.Add(EaseTypes.easeOutQuint, Easings.EaseOutQuint);
        easingCombiner.Add(EaseTypes.easeInOutQuint, Easings.EaseInOutQuint);

        easingCombiner.Add(EaseTypes.easeInCirc, Easings.EaseInCirc);
        easingCombiner.Add(EaseTypes.easeOutCirc, Easings.EaseOutCirc);
        easingCombiner.Add(EaseTypes.easeInOutCirc, Easings.EaseInOutCirc);

        easingCombiner.Add(EaseTypes.easeInElastic, Easings.EaseInElastic);
        easingCombiner.Add(EaseTypes.easeOutElastic, Easings.EaseOutElastic);
        easingCombiner.Add(EaseTypes.easeInOutElastic, Easings.EaseInOutElastic);

        easingCombiner.Add(EaseTypes.easeInQuad, Easings.EaseInQuad);
        easingCombiner.Add(EaseTypes.easeOutQuad, Easings.EaseOutQuad);
        easingCombiner.Add(EaseTypes.easeInOutQuad, Easings.EaseInOutQuad);

        easingCombiner.Add(EaseTypes.easeInQuart, Easings.EaseInQuart);
        easingCombiner.Add(EaseTypes.easeOutQuart, Easings.EaseOutQuart);
        easingCombiner.Add(EaseTypes.easeInOutQuart, Easings.EaseInOutQuart);

        easingCombiner.Add(EaseTypes.easeInExpo, Easings.EaseInExpo);
        easingCombiner.Add(EaseTypes.easeOutExpo, Easings.EaseOutExpo);
        easingCombiner.Add(EaseTypes.easeInOutExpo, Easings.EaseInOutExpo);

        easingCombiner.Add(EaseTypes.easeInBack, Easings.EaseInBack);
        easingCombiner.Add(EaseTypes.easeOutBack, Easings.EaseOutBack);
        easingCombiner.Add(EaseTypes.easeInOutBack, Easings.EaseInOutBack);

        easingCombiner.Add(EaseTypes.easeInBounce, Easings.EaseInBounce);
        easingCombiner.Add(EaseTypes.easeOutBounce, Easings.EaseOutBounce);
        easingCombiner.Add(EaseTypes.easeInOutBounce, Easings.EaseInOutBounce);
    }

    private void Update()
    {
        if (_activeTweens.Count < 1) return;
        
        for (int i = 0; i < _activeTweens.Count; i++)
        {
            _activeTweens[i].UpdateTween(Time.deltaTime);
        }
    }

    public void MoveGameObject(GameObject objectToMove, Vector3 targetPosition, float speed, EaseTypes type)
    {
        Debug.Log(type);
        TweenPosition newTween = new TweenPosition(objectToMove, targetPosition, speed, easingCombiner[type]);
        _activeTweens.Add(newTween);
    }

    public void RotateGameObject(GameObject objectRotate, Vector3 targetRotation, float RotationSpeed, EaseTypes type)
    {
        Debug.Log(type);
        TweenRotate newTween = new TweenRotate(objectRotate, targetRotation, RotationSpeed, easingCombiner[type]);
        _activeTweens.Add(newTween);
    }
    public static TweenMachine GetInstance()
    {
        return instance;
    }
}
