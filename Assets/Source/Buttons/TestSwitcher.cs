using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class TestSwitcher : MonoBehaviour
{
    [SerializeField] private Page _currentPage;
    [SerializeField] private Page _nextPage;
    [SerializeField] private QuestionCounter _questionCounter;
    [SerializeField] private bool _isEnabling;
    [SerializeField] private QuizCore _quizCore;

    protected Button Button;

    private readonly float _scaleDuration = 0.2f;

    private void Awake()
    {
        Button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        Button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        Button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        if (_isEnabling)
        {
            _questionCounter.transform.localScale = new Vector3(0, 0, 0);
            _questionCounter.gameObject.SetActive(true);
            _questionCounter.transform.DOScale(1, _scaleDuration);
        }
        else
        {
            _questionCounter.transform.localScale = new Vector3(1, 1, 1);
            _questionCounter.transform.DOScale(0, _scaleDuration);
            _questionCounter.ResetCount();
            _quizCore.ResetScore();
        }

        _currentPage.SwitchPage(_nextPage);
    }
}
