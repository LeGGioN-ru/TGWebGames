using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerDigit : Answer
{
    [SerializeField] private Slider _slider;

    protected override void OnClick()
    {
        Clicked?.Invoke(_slider.value.ToString());
    }
}
