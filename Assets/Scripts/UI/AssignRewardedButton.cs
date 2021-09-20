using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignRewardedButton : RewardedButton
{
    [SerializeField] private RewardType _reward;

    private void Start()
    {
        base.SetReward(_reward);
    }

}
