using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class QuizReseter : MonoBehaviour
{
    [SerializeField] private Question[] _questions;

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
        foreach (Question question in _questions)
            question.ResetQuestion();
    }
}
