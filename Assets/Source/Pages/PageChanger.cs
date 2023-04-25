using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PageChanger : MonoBehaviour
{
    [SerializeField] private Page _currentPage;
    [SerializeField] private Page _nextPage;

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
        _currentPage.SwitchPage(_nextPage);
    }
}