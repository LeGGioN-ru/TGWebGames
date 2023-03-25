using Lean.Localization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizEndScreen : EndScreen
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private TMP_Text _points;
    [SerializeField] private string _questionsCount;

    public void SetUI(QuizResult quizResult, int collectedPoints)
    {
        _image.sprite = quizResult.Image;
        _description.text = LeanLocalization.GetTranslationText(quizResult.Description);
        _points.text = $"{collectedPoints}/{_questionsCount}";
        _name.text = LeanLocalization.GetTranslationText(quizResult.Name);
    }
}

