using System;
using UnityEngine;

public class QuizCore : Core, IQuizable
{
    [SerializeField] private QuizEndScreen _quizEndScreen;
    [SerializeField] private int _health;

    private int _score;

    public int Score => _score;

    public Action RightAnswered;
    public Action WrongAnswered;

    public void ReduceHealth()
    {
        WrongAnswered?.Invoke();
        _health--;
    }

    public void AddScore()
    {
        RightAnswered?.Invoke();
        _score++;
    }

    public void ResetScore()
    {
        _score = 0;
    }

    public void Lose(Page currentPage)
    {
        currentPage.SwitchPage(_quizEndScreen);
    }
}

public interface IQuizable
{
    public void ReduceHealth();
    public void AddScore();
}