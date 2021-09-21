using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(CanvasGroup))]
public class NoThanksButton : MonoBehaviour
{
    [SerializeField] PopUp _parentPopUp;
    [SerializeField] float _delay;
    [SerializeField] float _fadeAnimationTime;
    private Button _button;
    private CanvasGroup _canvasGroup = null;
    public event Action Click;


    void OnEnable()
    {
        SetVisible(false);
        StartCoroutine(ShowWithDelay());
    }

    private void Start()
    {
        _button = gameObject.GetComponent<Button>();
        _button.onClick.AddListener(onClick);
    }

    private IEnumerator ShowWithDelay()
    {
        yield return new WaitForSecondsRealtime(_delay);
        SetVisible(true);
    }

    private void onClick()
    {
        Click?.Invoke();
        _parentPopUp.SetVisible(false);
    }

    private void SetVisible(bool visible)
    {
        if (_canvasGroup == null)
            _canvasGroup = gameObject.GetComponent<CanvasGroup>();


        if (visible)
        {
            _canvasGroup.interactable = true;
            _canvasGroup.DOFade(1f, _fadeAnimationTime).SetUpdate(true);
        }
        else
        {
            _canvasGroup.interactable = false;
            _canvasGroup.alpha = 0f;
        }
    }

}
