using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyController : MonoBehaviour
{
    [SerializeField] Material material;

    int animationStatus = 0;
    float animationElapsedTime, animationProgress, animationDuration;
    float defaultAnimDuration = 1f;
    [SerializeField] float currentLevel, targetLevel, difference;

    private void Start()
    {
        material.SetFloat("_GreyIntensity", 0f);
    }

    void FixedUpdate()
    {
        if (animationStatus != 0)
        {
            animationElapsedTime += Time.deltaTime;
            animationProgress = animationElapsedTime / animationDuration;

            if (animationProgress >= 1)
            {
                animationProgress = 1;
                if (animationStatus == 1)
                {
                    animationStatus = 0;
                }
            }
            else if (animationStatus == 1)
            {
                material.SetFloat("_GreyIntensity", currentLevel + difference * animationProgress);
            }
        }
    }

    public void SetTargetValue(float _targetValue)
    {
        _targetValue *= .8f;
        currentLevel = material.GetFloat("_GreyIntensity");
        targetLevel = _targetValue;
        difference =  _targetValue - currentLevel;
        animationElapsedTime = 0;
        animationProgress = 0;
        animationDuration = defaultAnimDuration;
        animationStatus = 1;
    }

}
