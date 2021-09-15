using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class RewardedButton : MonoBehaviour
{
    [SerializeField] private PopUp _parentPopUp;
    private RewardSystem _rewardSystem;
    private RewardType? _reward = null;

    public void SetReward(RewardType reward)
    {
        _reward = reward;
    }

    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(onClick);
        _rewardSystem = FindObjectOfType<RewardSystem>();

    }

    private void onClick()
    {
        if (_reward == null)
            throw new System.Exception("Reward button is not init");

        _rewardSystem.PlayReward((RewardType)_reward);
        _rewardSystem.RewardGiven += OnRewardGiven;
    }
    private void OnRewardGiven()
    {
        _parentPopUp.SetVisible(false);
    }

    private void OnDisable()
    {
        if (_rewardSystem != null)
            _rewardSystem.RewardGiven -= OnRewardGiven;
    }

}
