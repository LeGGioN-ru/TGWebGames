using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SoundMuterButton : MonoBehaviour
{
    private bool _isPlaying = true;
    private Button _button;

    public bool IsPlaying => _isPlaying;

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
        if (_isPlaying == false)
        {
            _isPlaying = true;
            AudioListener.volume = 1.0f;
        }
        else
        {
            _isPlaying = false;
            AudioListener.volume = 0.0f;
        }

    }
}
