using System;
using UnityEngine;
using Agava.YandexGames;
public abstract class Question : Page
{
    [SerializeField] protected Answer[] Answers;
    [SerializeField] private SoundMuterButton _soundMuter;

    public Action Answered;

    private void OnEnable()
    {
        foreach (Answer answer in Answers)
        {
            answer.Clicked += OnClick;
        }
    }

    private void OnDisable()
    {
        foreach (Answer answer in Answers)
        {
            answer.Clicked -= OnClick;
        }
    }

    private void OnClick(Answer answer)
    {
        OnAnswerClick(answer);
        Answered?.Invoke();
    }

    public void SkipQuestion()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        VideoAd.Show(() => AudioListener.volume = 0, AdvertisingExecute, DisableSound, null);
#endif
    }

    public abstract void ResetQuestion();

    protected virtual void AdvertisingExecute()
    {
        Answered?.Invoke();
    }

    private void DisableSound()
    {
        if (_soundMuter.IsPlaying == true)
            AudioListener.volume = 1;
        else
            AudioListener.volume = 0;
    }

    protected abstract void OnAnswerClick(Answer answer);
}
