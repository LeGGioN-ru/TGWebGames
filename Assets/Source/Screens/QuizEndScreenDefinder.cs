using System;
using System.Linq;
using UnityEngine;

public class QuizEndScreenDefinder : MonoBehaviour
{
    [SerializeField] private QuizEndScreen _quizEndScreen;
    [SerializeField] private QuizResult[] _quizResults;
    [SerializeField] private QuizCore _quizCore;

    private void OnEnable()
    {
        _quizEndScreen.SetUI(Execute());
    }

    private QuizResult Execute()
    {
        if (_quizCore.Score <= _quizResults.FirstOrDefault().Score)
            return _quizResults.FirstOrDefault();

        for (int i = 0; i < _quizResults.Length; i++)
        {
            if (i + 1 >= _quizResults.Length)
                break;

            if (_quizResults[i].Score <= _quizCore.Score && _quizCore.Score < _quizResults[i + 1].Score)
                return _quizResults[i];
        }

        return _quizResults[_quizResults.Length - 1];
    }
}

[Serializable]
public class QuizResult
{
    [SerializeField] private int _score;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _image;

    public int Score => _score;
    public Sprite Image => _image;
    public string Description => _description;  
}
