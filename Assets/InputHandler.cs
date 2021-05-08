using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
using UnityEngine.UI;
using TMPro;

public class InputHandler : MonoBehaviour
{
    Slider slider;
    float currentValue;
    public float backTime = 0.5f;
    public float distanceThreshold = 0.2f;

    public bool clicked = false;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    private void Update()
    {
        if (LeanTouch.Fingers.Count <= 1)
        {
            currentValue = slider.value;
            slider.value = Mathf.Lerp(currentValue, 0, backTime);
            if (slider.value < 0.05) slider.value = 0;
        }
    }

    public void OnClick()
    {
        if (slider.value == 0)
        {
            clicked = true;
        }
        else if (slider.value >= distanceThreshold || slider.value <= distanceThreshold)
        {
            clicked = false;
        }
    }
}
