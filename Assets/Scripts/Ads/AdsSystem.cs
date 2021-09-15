using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AdsSystem : MonoBehaviour
{
    public abstract event Action<RewardType> EarnedReward;
    abstract public void ShowInterstitialVideo();
    abstract public void ShowBanner();
    abstract public void HideBanner();

    abstract public void ShowRewardedVideo(AdType rewardType);
}
