using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class SoundMuterButton : MonoBehaviour
{
    [SerializeField] private Sprite _onSound;
    [SerializeField] private Sprite _offSound;

    private bool _isPlaying = true;
    private Button _button;
    private Image _image;

    public bool IsPlaying => _isPlaying;

    private void Awake()
    {
        _image = GetComponent<Image>();
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
        if (_isPlaying == false)
        {
            _isPlaying = true;
            AudioListener.volume = 1.0f;
            _image.sprite = _onSound;
        }
        else
        {
            _image.sprite = _offSound;
            _isPlaying = false;
            AudioListener.volume = 0.0f;
        }

    }
}
