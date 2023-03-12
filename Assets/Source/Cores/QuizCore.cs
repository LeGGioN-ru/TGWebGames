using UnityEngine;

public class QuizCore : Core, IQuizable
{
    [SerializeField] private QuizEndScreen _quizEndScreen;
    [SerializeField] private int _health;
    [SerializeField] private QuestionsRoot _questionRoot;

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

    public void Lose()
    {
        _quizEndScreen.gameObject.SetActive(true);
        _questionRoot.gameObject.SetActive(false);
    }
}

public interface IQuizable
{
    bool IsAlive { get; }

    public void ReduceHealth();
    public void AddScore();
}