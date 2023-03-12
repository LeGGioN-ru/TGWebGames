using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class ButtonAdditional : MonoBehaviour
{
    protected Button Button;

    private void Awake()
    {
        Button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        if (Button != null)
            Button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        if (Button != null)
            Button.onClick.RemoveListener(OnClick);
    }

    protected abstract void OnClick();
}
