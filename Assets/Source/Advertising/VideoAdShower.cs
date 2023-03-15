using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class VideoAdShower : MonoBehaviour
{
    [SerializeField] private QuizDefaultQuestion _question;
    [SerializeField] private QuizDigitQuestion _digitQuestion;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        if (_question != null)
            _question.SkipQuestion();

        if (_digitQuestion != null)
            _digitQuestion.SkipQuestion();
    }
}
