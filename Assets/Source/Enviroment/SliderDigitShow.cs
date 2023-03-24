using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderDigitShow : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _text.text = _slider.minValue.ToString();
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(OnChange);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(OnChange);
    }

    private void OnChange(float value)
    {
        _text.text = value.ToString();
    }

    public void ResetSlider()
    {
        _text.text = _slider.minValue.ToString();
        _slider.value = _slider.minValue;
    }
}
