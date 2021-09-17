using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardSystem : MonoBehaviour
{
    public event Action RewardGiven;

    [SerializeField] private AdsSystem _adsSystem;
    private RewardType _currentReward;
    [SerializeField] private UI.BoosterSystem _boosterSystem;

    private void Start()
    {
        _adsSystem.EarnedReward += GiveReward;
    }

    public void PlayReward(RewardType reward)
    {
        _currentReward = reward;
        _adsSystem.ShowRewardedVideo(Util.Converter.RewardToAdType(reward));
    }

    private void GiveReward(RewardType reward)
    {
        RewardGiven?.Invoke();

        if (reward == RewardType.Bomb)
        {
            _boosterSystem.AddBooster(BoosterType.Bomb, 1);
        }
        else if (reward == RewardType.Doubler)
        {
            _boosterSystem.AddBooster(BoosterType.Doubler, 1);
        }
        else
        {
            throw new Exception("GiveReward can't resolve this reward type: " + reward.ToString());
        }


    }
}
