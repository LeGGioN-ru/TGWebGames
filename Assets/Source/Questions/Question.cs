using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class Question : MonoBehaviour
{
    [SerializeField] protected Answer[] Answers;

    private void OnEnable()
    {
        foreach (Answer answer in Answers)
        {
            answer.Clicked += OnAnswerClick;
        }
    }

    private void OnDisable()
    {
        foreach (Answer answer in Answers)
        {
            answer.Clicked += OnAnswerClick;
        }
    }

    protected abstract void OnAnswerClick(string answer);
}
