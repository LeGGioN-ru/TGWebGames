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

    private void OnClick(Answer answer)
    {
        OnAnswerClick(answer);
        Answered?.Invoke();
    }

    public void SkipQuestion()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
 VideoAd.Show(null, NextPage);
#endif
    }

    protected abstract void AdvertisingExecute();

    protected abstract void OnAnswerClick(Answer answer);
}
