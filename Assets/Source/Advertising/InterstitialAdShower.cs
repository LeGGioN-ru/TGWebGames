using Agava.YandexGames;
using UnityEngine;

public class InterstitialAdShower : MonoBehaviour
{
    private void OnEnable()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
InterstitialAd.Show();
#endif
    }
}
