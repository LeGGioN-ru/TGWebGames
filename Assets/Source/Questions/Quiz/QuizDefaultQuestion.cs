using UnityEngine;

public class QuizDefaultQuestion : Question
{
    [SerializeField] private Page _nextPage;
    [SerializeField] private Answer _rightAnswer;
    [SerializeField] private AudioSource _rightSound;
    [SerializeField] private AudioSource _wrongSound;

    private QuizCore _quizCore;

    public IQuizable IQuizCore => _quizCore;

    private void Awake()
    {
        _quizCore = GetComponentInParent<QuizCore>();
    }

    protected override void OnAnswerClick(Answer answer)
    {
        if (answer == _rightAnswer)
        {
            _rightSound.Play();
            _quizCore.AddScore();
        }
        else
        {
            _wrongSound.Play();
            _quizCore.ReduceHealth();
        }

        SwitchPage(_nextPage);
    }

    protected override void AdvertisingExecute()
    {
        base.AdvertisingExecute();
        _quizCore.AddScore();
        SwitchPage(_nextPage);
    }

    public override void ResetQuestion()
    {

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

