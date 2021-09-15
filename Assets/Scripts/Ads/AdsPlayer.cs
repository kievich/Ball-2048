using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AdsPlayer : MonoBehaviour
{
    [SerializeField] private AdsSystem _adsSystem;


    private void Start()
    {
        _adsSystem.ShowBanner();
        BallUnifier.BallUnited += onBallUnited;
    }


    private void onBallUnited(int value)
    {
        //_adsSystem.ShowRewardedVideo(AdType.DoublerReward);

    }


}
