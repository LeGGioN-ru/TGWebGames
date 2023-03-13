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
        _text.text = "0";
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
}
