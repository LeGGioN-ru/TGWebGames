using Lean.Localization;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using Agava.YandexGames;

public class GameInitializator : MonoBehaviour
{
    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
   
        yield break;
#endif

        yield return YandexGamesSdk.Initialize();

        LeanLocalization.SetCurrentLanguageAll(YandexGamesSdk.Environment.i18n.lang);
    }
}
