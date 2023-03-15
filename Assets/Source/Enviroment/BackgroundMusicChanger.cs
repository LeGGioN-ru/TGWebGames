using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BackgroundMusicChanger : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _clip;

    private readonly float _hideDelay = 1;
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
        _source.DOFade(0, _hideDelay).onComplete += OnComplete;
        _source.DOFade(1, _hideDelay).SetDelay(_hideDelay);
    }

    private void OnComplete()
    {
        _source.clip = _clip;
        _source.Play();
    }
}
