using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(QuizCore))]
public class WrongRightAnswerShower : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Sprite _rightAnswer;
    [SerializeField] private Sprite _wrongAnswer;

    private QuizCore _quizCore;
    private readonly float _duration = 0.3f;

    private void Awake()
    {
        _quizCore = GetComponent<QuizCore>();
    }

    private void OnEnable()
    {
        _quizCore.RightAnswered += OnRightAnswered;
        _quizCore.WrongAnswered += OnWrongAnswered;
    }

    private void OnDisable()
    {
        _quizCore.RightAnswered -= OnRightAnswered;
        _quizCore.WrongAnswered -= OnWrongAnswered;
    }

    private void OnWrongAnswered()
    {
        ShowAnswerColor(_wrongAnswer);
    }

    private void OnRightAnswered()
    {
        ShowAnswerColor(_rightAnswer);
    }

    private void ShowAnswerColor(Sprite sprite)
    {
        _image.color = new Color(0, 0, 0, 0);

        _image.sprite = sprite;
        _image.DOColor(new Color(1, 1, 1, 1), _duration);

        _image.DOColor(new Color(0, 0, 0, 0), _duration).SetDelay(_duration);
    }
}
