using Agava.YandexGames;
using DG.Tweening;
using System;
using TMPro;
using UnityEngine;

public class QuizDefaultQuestion : Question
{
    [SerializeField] private Page _nextPage;
    [SerializeField] private TMP_Text _rightAnswer;
    [SerializeField] private GameObject[] _parts;

    [SerializeField] private Transform _startPositionRight;
    [SerializeField] private Transform _startPositionLeft;
    [SerializeField] private Transform _startPositionUp;

    private QuizCore _quizCore;

    public IQuizable IQuizCore => _quizCore;

    private void Awake()
    {
        _quizCore = GetComponentInParent<QuizCore>();

        if (_quizCore == null)
            throw new Exception("Нету нужного ядра (ядра для викторин)");
    }

    protected override void OnAnswerClick(string answer)
    {
        if (answer == _rightAnswer.text)
            _quizCore.AddScore();

        SwitchPage(_nextPage);
    }

    public void SkipQuestion()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
 VideoAd.Show(null, NextPage);
#endif
    }

    private void NextPage()
    {
        _quizCore.AddScore();
        SwitchPage(_nextPage);
    }

    //public override void Animate(Page nextPage)
    //{
    //    Hide();
    //    Show(nextPage);
    //}
    ////TODO Вынести эту хуйню в отдельный класс
    //public override void Hide()
    //{
    //    _parts[0].transform.DOMoveX(_parts[0].transform.position.x + 1000, 0.4f);
    //    _parts[1].transform.DOMoveX(_parts[1].transform.position.x - 1200, 0.4f);
    //    _parts[2].transform.DOMoveY(_parts[2].transform.position.y + 1100, 0.4f);

    //}

    //public override void Show(Page nextPage, bool isNeedDelay = true)
    //{
    //    base.Show(nextPage, isNeedDelay);
    //}
}

