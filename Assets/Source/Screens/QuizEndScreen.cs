using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizEndScreen : EndScreen
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _text;

    public void SetUI(QuizResult quizResult)
    {
        _image.sprite = quizResult.Image;
        _text.text = quizResult.Description;
    }
}

