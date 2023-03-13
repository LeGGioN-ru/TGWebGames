using UnityEngine;

public abstract class Core : MonoBehaviour
{
    private void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR

        yield return YandexGamesSdk.Initialize();

        LeanLocalization.SetCurrentLanguageAll(YandexGamesSdk.Environment.i18n.lang);
#endif
    }
}
