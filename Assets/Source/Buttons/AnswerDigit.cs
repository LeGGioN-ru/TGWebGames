using UnityEngine;
using UnityEngine.UI;

public class AnswerDigit : Answer
{
    [SerializeField] private Slider _slider;

    public Slider Slider => _slider;

    protected override void OnClick()
    {
        Clicked?.Invoke(this);
    }
}
