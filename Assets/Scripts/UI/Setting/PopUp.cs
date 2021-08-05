using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{

    [SerializeField] private CanvasGroup _backgroundPanel;
    [SerializeField] private CanvasGroup _elementsPanel;
    [SerializeField] private CanvasGroup _container;
    [SerializeField] private float _animationDuration;
    [SerializeField] private Vector3 _elementsMinSize;
    [SerializeField] private bool _enableOnStart;


    private void Start()
    {
        SetStartPosition();
        Disable();

        if (_enableOnStart)
            SetVisible(true);

    }

    private void SetStartPosition()
    {
        _elementsPanel.transform.localScale = _elementsMinSize;
        _elementsPanel.alpha = 0;
        _backgroundPanel.alpha = 0;
    }

    private void Enable()
    {
        _container.gameObject.SetActive(true);
    }

    private void Disable()
    {
        _container.gameObject.SetActive(false);
    }


    public void SetVisible(bool visible)
    {
        if (visible)
            StartCoroutine(Show());
        else
            StartCoroutine(Hide());
    }


    private IEnumerator Hide()
    {
        _elementsPanel.transform.DOScale(_elementsMinSize, _animationDuration / 2).SetEase(Ease.InBack); ;
        _elementsPanel.DOFade(0f, _animationDuration / 2);

        yield return new WaitForSeconds(_animationDuration / 2);
        _backgroundPanel.DOFade(0, _animationDuration / 2);

        yield return new WaitForSeconds(_animationDuration / 2);
        Disable();

    }

    private IEnumerator Show()
    {
        Enable();
        _backgroundPanel.DOFade(1, _animationDuration / 2);

        yield return new WaitForSeconds(_animationDuration / 2);

        _elementsPanel.transform.DOScale(Vector3.one, _animationDuration / 2).SetEase(Ease.OutBack);
        _elementsPanel.DOFade(1f, _animationDuration / 2);

    }

}
