using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class StartTestButton : MonoBehaviour
{
    [SerializeField] private Question _firstQuestion;
    [SerializeField] private MainScreen _mainScreen;

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
        _firstQuestion.gameObject.SetActive(true);
        _mainScreen.gameObject.SetActive(false);
    }
}
