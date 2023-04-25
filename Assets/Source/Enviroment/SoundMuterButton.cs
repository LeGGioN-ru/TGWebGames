using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class SoundMuterButton : MonoBehaviour
{
    [SerializeField] private Sprite _onSound;
    [SerializeField] private Sprite _offSound;

    private Button _button;
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
        _button.onClick.AddListener(SoundMuter.Instance.SwitchSound);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
        _button.onClick.RemoveListener(SoundMuter.Instance.SwitchSound);
    }

    private void OnClick()
    {
        if (SoundMuter.Instance.IsPlaying == false)
        {
            _image.sprite = _onSound;
            return;
        }

        _image.sprite = _offSound;
    }
}
