using UnityEngine;
using UnityEngine.UI;

public class TestEnder : TestSwitcher
{
    [SerializeField] private Image _realEndScreen;

    protected override void OnClick()
    {
        _realEndScreen.gameObject.SetActive(false);
        base.OnClick();
    }
}
