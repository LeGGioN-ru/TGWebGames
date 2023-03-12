using UnityEngine;

public class QuizCore : Core, IQuizable
{
    [SerializeField] private QuizEndScreen _quizEndScreen;
    [SerializeField] private int _health;

    private int _score;

    public bool IsAlive { get => _health > 0; }

    public void ReduceHealth()
    {
        _health--;
    }

    public void AddScore()
    {
        _score++;
    }

    public void Lose(Page currentPage)
    {
        currentPage.SwitchPage(_quizEndScreen);
    }
}

public interface IQuizable
{
    bool IsAlive { get; }

    public void ReduceHealth();
    public void AddScore();
}