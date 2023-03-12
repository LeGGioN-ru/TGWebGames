using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundClick : ButtonAdditional
{
    private AudioSource _sound;

    private void Start()
    {
        _sound = GetComponent<AudioSource>();
    }

    protected override void OnClick()
    {
        if (_sound.clip != null)
            _sound.Play();
    }
}
