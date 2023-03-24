using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class OurGamesButton : MonoBehaviour
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
        System.Diagnostics.Process.Start(new ProcessStartInfo
        {
            FileName = "https://yandex.ru/games/developer?name=Lazy%20Cat",
            UseShellExecute = true
        });
    }
}
