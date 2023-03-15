using Agava.WebUtility;
using UnityEngine;

[RequireComponent(typeof(SoundMuterButton))]
public class SoundMuter : MonoBehaviour
{
    private SoundMuterButton _soundMuterButton;

    private void Awake()
    {
        _soundMuterButton = GetComponent<SoundMuterButton>();
    }

    private void OnEnable()
    {
        WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;
    }

    private void OnDisable()
    {
        WebApplication.InBackgroundChangeEvent -= OnInBackgroundChange;
    }

    private void OnInBackgroundChange(bool inBackground)
    {
        AudioListener.pause = inBackground;

        if (_soundMuterButton.IsPlaying)
            AudioListener.volume = inBackground ? 0f : 1f;
    }
}
