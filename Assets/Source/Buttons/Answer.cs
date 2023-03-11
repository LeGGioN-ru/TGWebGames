using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class Answer : MonoBehaviour
{
    protected Button Button;

    public Action<string> Clicked;

    private void Awake()
    {
        Button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        Button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        Button.onClick.RemoveListener(OnClick);
    }

    protected abstract void OnClick();
}
