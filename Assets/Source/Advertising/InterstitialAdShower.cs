using UnityEngine;
using UnityEngine.UI;
using Agava.YandexGames;

[RequireComponent(typeof(Button))]
public class InterstitialAdShower : MonoBehaviour
{
    private Button _button;

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
#if UNITY_WEBGL && !UNITY_EDITOR
        InterstitialAd.Show(() => AudioListener.volume = 0, DisableSound);
#endif
    }

    private void DisableSound(bool s)
    {
        if (SoundMuter.Instance.IsPlaying == true)
            AudioListener.volume = 1;
        else
            AudioListener.volume = 0;
    }
}
