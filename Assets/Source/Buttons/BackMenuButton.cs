using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BackMenuButton : MonoBehaviour
{
    [SerializeField] private MainScreen _mainScreen;
    [SerializeField] private EndScreen _endScreen;

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
        _mainScreen.gameObject.SetActive(true);
        _endScreen.gameObject.SetActive(false);
    }
}
