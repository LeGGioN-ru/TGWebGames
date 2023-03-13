using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class AnswerString : Answer
{
    private string _text;

    private void Start()
    {
        _text = Button.GetComponentInChildren<TMP_Text>().text;
    }

    protected override void OnClick()
    {
        Clicked?.Invoke(this);
    }
}
