using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class GameSaver : MonoBehaviour
{
    [SerializeField] private int _testNumber;
    [SerializeField] private QuizCore _quizCore;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(Execute);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Execute);
    }

    private void Execute()
    {
        int previosRecord = PlayerPrefs.GetInt($"Test {_testNumber}");

        if (previosRecord > _quizCore.Score)
            return;

        PlayerPrefs.SetInt($"Test {_testNumber}", _quizCore.Score);
        PlayerPrefs.Save();
    }
}
