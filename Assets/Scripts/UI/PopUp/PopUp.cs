using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class PopUp : MonoBehaviour
{

    [SerializeField] private CanvasGroup _backgroundPanel;
    [SerializeField] private CanvasGroup _elementsPanel;
    [SerializeField] private CanvasGroup _container;
    [SerializeField] private float _animationDuration;
    [SerializeField] private Vector3 _elementsMinSize;
    [SerializeField] private PopUpMode _mode;
    [SerializeField] private bool _enableOnStart;

    private LevelPause _levelPause;
    private static bool _isShowed = false;
    private static Queue<PopUp> _queue = new Queue<PopUp>();

    public event Action Showed;
    public event Action Hided;

    private void Start()
    {
        _levelPause = FindObjectOfType<LevelPause>();

        SetStartPosition();
        Disable();

        if (_enableOnStart)
            SetVisible(true);

        _isShowed = false;
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

        if (visible && _isShowed == false || visible && _mode == PopUpMode.Overlay)
            StartCoroutine(Show());
        else if (visible && _isShowed && _mode == PopUpMode.Queue)
            _queue.Enqueue(this);
        else if (visible == false)
            StartCoroutine(Hide());
    }


    private IEnumerator Hide()
    {

        if (_mode != PopUpMode.Overlay)
            _isShowed = false;

        Hided?.Invoke();
        _elementsPanel.transform.DOScale(_elementsMinSize, _animationDuration / 2).SetEase(Ease.InBack).SetUpdate(true);
        _elementsPanel.DOFade(0f, _animationDuration / 2).SetUpdate(true);

        yield return new WaitForSecondsRealtime(_animationDuration / 2);
        _backgroundPanel.DOFade(0, _animationDuration / 2).SetUpdate(true);

        yield return new WaitForSecondsRealtime(_animationDuration / 2);
        Disable();

        if (_isShowed == false)
            _levelPause.ResumeGame();
        ShowFromQueue();
    }

    private IEnumerator Show()
    {
        if (_mode != PopUpMode.Overlay)
            _isShowed = true;

        Showed?.Invoke();
        Enable();
        _backgroundPanel.DOFade(1, _animationDuration / 2).SetUpdate(true);

        yield return new WaitForSecondsRealtime(_animationDuration / 2);

        _elementsPanel.transform.DOScale(Vector3.one, _animationDuration / 2).SetEase(Ease.OutBack).SetUpdate(true);
        _elementsPanel.DOFade(1f, _animationDuration / 2).SetUpdate(true);
        _levelPause.PauseGame();

    }

    private void ShowFromQueue()
    {
        if (_queue.Count != 0)
        {
            PopUp popUp = _queue.Dequeue();
            popUp.SetVisible(true);
        }
    }

}
