using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizCore : MonoBehaviour, IQuizable
{
    [SerializeField] private int _health;
    
    private int _score;

    public void ReduceHealth()
    {
        Debug.Log("wrong");
        _health--;
    }

    public void AddScore()
    {
        Debug.Log("nice");
        _score++;
    }
}

public interface IQuizable
{
    public void ReduceHealth();
    public void AddScore();
}