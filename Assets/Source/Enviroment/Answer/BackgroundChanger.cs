using UnityEngine;
using UnityEngine.UI;

public class BackgroundChanger : ButtonAdditional
{
    [SerializeField] private Image _background;
    [SerializeField] private Sprite _image;

    protected override void OnClick()
    {
        if (_background != null && _image != null)
            _background.sprite = _image;
    }
}
