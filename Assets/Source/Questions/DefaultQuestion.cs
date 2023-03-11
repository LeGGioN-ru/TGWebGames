using System;
using UnityEngine;

public class DefaultQuestion : Question
{
    [SerializeField] private Question _nextQuestion;

    private QuizCore _quizCore;

    public IQuizable IQuizCore => _quizCore;

    private void Awake()
    {
        _quizCore = GetComponentInParent<QuizCore>();

        if (_quizCore == null)
            throw new Exception("Нету нужного ядра (ядра для викторин)");
    }

    public void SwitchQuestion()
    {
        gameObject.SetActive(false);
        _nextQuestion.gameObject.SetActive(true);
    }
}
