using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class VideoAdShower : MonoBehaviour
{
    [SerializeField] private QuizDefaultQuestion _question;

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
        _question.SkipQuestion();
    }
}
