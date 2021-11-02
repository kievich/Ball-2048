using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System.Threading;
using System;

public class AdmobAdsSystem : AdsSystem
{
    public override event Action<RewardType> EarnedReward;

    [SerializeField] private AdsUnitID _adsID;
    [SerializeField] private PopUp _adNotLoaded;

    private InterstitialAd _interstitialVideo;
    private BannerView _bannerView;
    private Dictionary<AdType, RewardedAd> _rewardedMap = new Dictionary<AdType, RewardedAd>();
    private RewardType _currentReward;

    private AdRequest _request;

    private void Awake()
    {
        InitAdmob();
        InitInterstitial();
        InitBanner();
        InitRewardedMap();
    }

    #region Initialization  
    private void InitAdmob()
    {
        MobileAds.Initialize(initStatus => { });
        _request = new AdRequest.Builder().Build();
    }
    private void InitInterstitial()
    {
        _interstitialVideo = new InterstitialAd(_adsID.GetID(AdType.InterstitialVideo));
        _interstitialVideo.LoadAd(_request);
    }
    private void InitBanner()
    {
        _bannerView = new BannerView(_adsID.GetID(AdType.Banner), AdSize.IABBanner, AdPosition.Bottom);
    }

    private void InitRewardedMap()
    {
        _rewardedMap.Add(AdType.BombReward, new RewardedAd(_adsID.GetID(AdType.BombReward)));
        _rewardedMap.Add(AdType.DoublerReward, new RewardedAd(_adsID.GetID(AdType.DoublerReward)));
        _rewardedMap.Add(AdType.ContinueReward, new RewardedAd(_adsID.GetID(AdType.ContinueReward)));

        foreach (var item in _rewardedMap)
            item.Value.LoadAd(_request);

    }
    #endregion 

    public override void ShowInterstitialVideo()
    {
        if (_interstitialVideo.IsLoaded())
        {
            _interstitialVideo.Show();
            _interstitialVideo.LoadAd(_request);
        }
        else
        {
            Debug.Log("Not Loaded");

        }

    }

    public override void ShowBanner()
    {
        _bannerView.LoadAd(_request);
    }

    public override void HideBanner()
    {
        _bannerView.Hide();
    }

    public override void ShowRewardedVideo(AdType rewardType)
    {
        if (_rewardedMap[rewardType].IsLoaded())
        {
            _rewardedMap[rewardType].Show();

            _rewardedMap[rewardType].OnUserEarnedReward += OnUserEarnedReward;
            _rewardedMap[rewardType].LoadAd(_request);
            _currentReward = Util.Converter.AdTypeToReward(rewardType);

        }
        else
        {
            _adNotLoaded.SetVisible(true);
        }

    }

    private void OnUserEarnedReward(object sender, EventArgs args)
    {
        EarnedReward?.Invoke(_currentReward);
    }

    private void OnDisable()
    {
        foreach (var item in _rewardedMap)
            item.Value.OnUserEarnedReward -= OnUserEarnedReward;
    }
}
