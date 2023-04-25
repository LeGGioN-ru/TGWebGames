using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;

public abstract class Page : MonoBehaviour
{
    private readonly float _showHideDuration = 0.4f;

    public Action Showed;

    public void SwitchPage(Page nextPage)
    {
        StartCoroutine(Disable(_showHideDuration));
        Animate(nextPage);
    }

    public void Animate(Page nextPage)
    {
        Hide();
        Show(nextPage);
    }

    public void Hide()
    {
        transform.DOScale(0, _showHideDuration);
    }

    public void Show(Page nextPage, bool isNeedDelay = true)
    {
        nextPage.transform.localScale = new Vector3(0, 0, 0);
        nextPage.gameObject.SetActive(true);

        if (isNeedDelay)
            nextPage.transform.DOScale(1, _showHideDuration).SetDelay(_showHideDuration);
        else
            nextPage.transform.DOScale(1, _showHideDuration);
    }

    private IEnumerator Disable(float delay)
    {
        float passedTime = 0;

        while (passedTime < delay)
        {
            passedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        gameObject.SetActive(false);
    }
}
