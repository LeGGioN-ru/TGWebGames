using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class ShowingText : MonoBehaviour
{
    private float _showDelay;
    private TMP_Text _text;
    private string _currentText;

    private void Awake()
    {
        _showDelay = 0.03f;
        _text = GetComponent<TMP_Text>();
        _currentText = _text.text;
        _text.text = string.Empty;
    }

    private IEnumerator Execute()
    {
        foreach (char letter in _currentText)
        {
            _text.text += letter;
            yield return new WaitForSeconds(_showDelay);
        }
    }

    private void OnEnable()
    {
        StartCoroutine(Execute());
    }

    private void OnDisable()
    {
        _text.text = string.Empty;
    }
}
