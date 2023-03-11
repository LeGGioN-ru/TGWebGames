using UnityEngine;

public class QuizAnswer : Answer
{
    [SerializeField] private DefaultQuestion _currentQuestion;
    [SerializeField] private bool _isTrue;

    protected override void OnClick()
    {
        if (_isTrue)
            _currentQuestion.IQuizCore.AddScore();
        else
            _currentQuestion.IQuizCore.ReduceHealth();

        _currentQuestion.SwitchQuestion();
    }
}
