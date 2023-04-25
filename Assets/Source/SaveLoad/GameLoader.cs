using Lean.Localization;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class GameLoader : MonoBehaviour
{
    [SerializeField] private Page _page;

    [SerializeField] private int _testNumber;
    [SerializeField] private int _maxResult;

    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
        Execute();
    }

    private void OnEnable()
    {
        Execute();
    }

    private void Execute()
    {
        int testResult = PlayerPrefs.GetInt($"Test {_testNumber}");

        if (testResult == 0)
            return;

        _text.text = $"{LeanLocalization.GetTranslationText("Лучший результат:")} {testResult}/{_maxResult}";
    }
}
