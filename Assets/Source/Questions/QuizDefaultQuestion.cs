using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizDefaultQuestion : Question
{
    [SerializeField] private Question _nextQuestion;
    [SerializeField] private TMP_Text _rightAnswer;

    private QuizCore _quizCore;

    public IQuizable IQuizCore => _quizCore;

    private void Awake()
    {
        _quizCore = GetComponentInParent<QuizCore>();

        if (_quizCore == null)
            throw new Exception("Нету нужного ядра (ядра для викторин)");
    }

    protected override void OnAnswerClick(string answer)
    {
        if (answer == _rightAnswer.text)
            _quizCore.AddScore();
        else
            _quizCore.ReduceHealth();

        if (_quizCore.IsAlive)
        {
            SwitchQuestion(_nextQuestion);
        }
        else
        {
            _quizCore.Lose();
        }
    }
}
