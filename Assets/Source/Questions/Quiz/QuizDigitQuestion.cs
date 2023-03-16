using UnityEngine;
using System;

//TODO ������� ����� questionQuiz
public class QuizDigitQuestion : Question
{
    [SerializeField] private Page _nextPage;
    [SerializeField] private int _rightAnswer;
    [SerializeField] private AudioSource _rightSound;
    [SerializeField] private AudioSource _wrongSound;

    private QuizCore _quizCore;

    public IQuizable IQuizCore => _quizCore;

    private void Awake()
    {
        _quizCore = GetComponentInParent<QuizCore>();

        if (Answers.Length != 1)
            throw new Exception("������ ������ ��� ������ ����� ������ ���� ���� 1");
    }

    protected override void OnAnswerClick(Answer answer)
    {
        if (answer is AnswerDigit answerDigit)
        {
            if (answerDigit.Slider.value == _rightAnswer)
            {
                _rightSound.Play();
                _quizCore.AddScore();
            }
            else
            {
                _wrongSound.Play();
                _quizCore.ReduceHealth();
            }

            SwitchPage(_nextPage);
        }
        else
        {
            throw new Exception("������ �������� �����, �������� Answer Digit");
        }
    }

    protected override void AdvertisingExecute()
    {
        _quizCore.AddScore();
        SwitchPage(_nextPage);
    }
}
