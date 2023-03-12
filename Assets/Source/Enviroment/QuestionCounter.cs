using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionCounter : MonoBehaviour
{
    [SerializeField] private Question[] _questions;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Slider _porgress;

    private float _counter = 0;

    private void OnEnable()
    {
        foreach (Question question in _questions)
            question.Answered += OnAnswered;
    }

    private void OnDisable()
    {
        foreach (Question question in _questions)
            question.Answered -= OnAnswered;
    }

    public void ResetCount()
    {
        _counter = 0;
        UpdateUI(_counter);
    }

    private void OnAnswered()
    {
        _counter++;
        UpdateUI(_counter);
    }

    private void UpdateUI(float count)
    {
        _porgress.value = count / _questions.Length;
    }
}
