using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public abstract class Question : MonoBehaviour
{
    [SerializeField] protected Answer[] Answers;

    private readonly float _showHideDuration = 0.4f;

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
            answer.Clicked -= OnAnswerClick;
        }
    }

    public void SwitchQuestion(Question nextQuestion)
    {
        transform.DOScale(0, _showHideDuration);
        nextQuestion.transform.localScale = new Vector3(0, 0, 0);
        nextQuestion.gameObject.SetActive(true);
        nextQuestion.transform.DOScale(1, _showHideDuration).SetDelay(_showHideDuration);
    }

    protected abstract void OnAnswerClick(string answer);
}
