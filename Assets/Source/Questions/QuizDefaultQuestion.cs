using System;
using UnityEngine;

public class QuizDefaultQuestion : Question
{
    [SerializeField] private Question _nextQuestion;
    [SerializeField] private Answer[] _answers;
    [SerializeField] private Answer _rightAnswer;

    private QuizCore _quizCore;

    public IQuizable IQuizCore => _quizCore;

    private void Awake()
    {
        _quizCore = GetComponentInParent<QuizCore>();

        if (_quizCore == null)
            throw new Exception("Нету нужного ядра (ядра для викторин)");
    }

    private void OnEnable()
    {
        foreach (Answer answer in _answers)
        {
            answer.Clicked += SwitchQuestion;
        }
    }

    private void OnDisable()
    {
        foreach (Answer answer in _answers)
        {
            answer.Clicked += SwitchQuestion;
        }
    }

    public void SwitchQuestion(Answer answer)
    {
        if (answer == _rightAnswer)
            _quizCore.AddScore();
        else
            _quizCore.ReduceHealth();

        if (_quizCore.IsAlive)
        {
            gameObject.SetActive(false);
            _nextQuestion.gameObject.SetActive(true);
        }
        else
        {
            _quizCore.Lose();
        }
    }
}
