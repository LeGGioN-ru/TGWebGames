using UnityEngine;
using System;
using UnityEngine.UI;

//TODO Сделать класс questionQuiz
public class QuizDigitQuestion : Question
{
    [SerializeField] private Page _nextPage;
    [SerializeField] private int _rightAnswer;
    [SerializeField] private AudioSource _rightSound;
    [SerializeField] private AudioSource _wrongSound;
    [SerializeField] private SliderDigitShow _slider;

    private QuizCore _quizCore;

    public IQuizable IQuizCore => _quizCore;

    private void Awake()
    {
        _quizCore = GetComponentInParent<QuizCore>();

        if (Answers.Length != 1)
            throw new Exception("Кнопка ответа при выборе числа должна быть лишь 1");
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
            throw new Exception("Пришёл неверный ответ, ожидался Answer Digit");
        }
    }

    protected override void AdvertisingExecute()
    {
        base.AdvertisingExecute();
        _quizCore.AddScore();
        SwitchPage(_nextPage);
    }

    public override void ResetQuestion()
    {
        _slider.ResetSlider();
    }
}
