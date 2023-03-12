using System;
using UnityEngine;

public abstract class Question : Page
{
    [SerializeField] protected Answer[] Answers;

    public Action Answered;

    private void OnEnable()
    {
        foreach (Answer answer in Answers)
        {
            answer.Clicked += OnClick;
        }
    }

    private void OnDisable()
    {
        foreach (Answer answer in Answers)
        {
            answer.Clicked -= OnClick;
        }
    }

    private void OnClick(string answer)
    {
        OnAnswerClick(answer);
        Answered?.Invoke();
    }

    protected abstract void OnAnswerClick(string answer);
}
