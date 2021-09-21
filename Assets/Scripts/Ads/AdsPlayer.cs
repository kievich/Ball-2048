using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AdsPlayer : MonoBehaviour
{
    [SerializeField] private AdsSystem _adsSystem;
    [SerializeField] private NoThanksButton _noThanksButton;

    [Range(1, 100)]
    [SerializeField] private int _probabilityOfAdAfterNoThanks;
    [SerializeField] private float _delayBeforeShowAdAfterNoThanks;
    private void Start()
    {
        _adsSystem.ShowBanner();
        _noThanksButton.Click += onBallCreatedPopUpClose;
    }

    private void onBallCreatedPopUpClose()
    {
        if (Random.Range(1, 100) <= _probabilityOfAdAfterNoThanks)
            StartCoroutine(ShowAdWithDelay());

    }

    private IEnumerator ShowAdWithDelay()
    {
        yield return new WaitForSeconds(_delayBeforeShowAdAfterNoThanks);
        _adsSystem.ShowInterstitialVideo();

    }

    private void OnDestroy()
    {
        _noThanksButton.Click -= onBallCreatedPopUpClose;
    }

}
