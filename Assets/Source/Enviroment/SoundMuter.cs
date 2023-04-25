using Agava.WebUtility;
using System;
using UnityEngine;

[RequireComponent(typeof(SoundMuterButton))]
public class SoundMuter : MonoBehaviour
{
    public static SoundMuter Instance;

    private bool _isPlaying = true;

    public bool IsPlaying => _isPlaying;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;
    }

    private void OnDisable()
    {
        WebApplication.InBackgroundChangeEvent -= OnInBackgroundChange;
    }

    public void SwitchSound()
    {
        if (_isPlaying == false)
        {
            _isPlaying = true;
            AudioListener.volume = 1.0f;
            return;
        }

        _isPlaying = false;
        AudioListener.volume = 0.0f;
    }
    private void OnInBackgroundChange(bool inBackground)
    {
        AudioListener.pause = inBackground;

        if (_isPlaying)
            AudioListener.volume = inBackground ? 0f : 1f;
    }
}
