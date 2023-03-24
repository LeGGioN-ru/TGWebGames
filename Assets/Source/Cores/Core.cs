using UnityEngine;
using Agava.YandexGames;
using Lean.Localization;
using System.Collections;
using UnityEngine.UI;

public abstract class Core : MonoBehaviour
{
    [SerializeField] private Image _loadScreen;

    private IEnumerator Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR

        yield return YandexGamesSdk.Initialize(()=> _loadScreen.gameObject.SetActive(false));

        LeanLocalization.SetCurrentLanguageAll(YandexGamesSdk.Environment.i18n.lang);
#endif

        _loadScreen.gameObject.SetActive(false);
        yield return null;
    }
}
