using System.Linq;
using UnityEngine;
using System;

public class QuestionsRoot : MonoBehaviour
{
    private Question[] _questions;

    private void Awake()
    { 
        _questions = GetComponentsInChildren<Question>();

        if (_questions.Length == 0)
            throw new Exception("�������� �� �������");

        if (_questions.Count(x => x.gameObject.activeSelf) > 1)
            throw new Exception("�������� ������ 1�� �������");
    }

    private void OnEnable()
    {
        _questions[0].Show(_questions[0], false);
    }
}
