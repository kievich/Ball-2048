using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Util;

public class AddBoosterPopUp : PopUp
{
    [SerializeField] private BoosterSprites _rewardSprites;
    [SerializeField] private RawImage _boosterImage;

    public void Show(string boosterType)
    {
        BoosterType booster = EnumHelper.ToEnum<BoosterType>(boosterType);

        _boosterImage.texture = _rewardSprites.GetSprite(booster);

        base.SetVisible(true);

        gameObject.GetComponentInChildren<RewardedButton>().SetReward(Util.Converter.BoosterToReward(booster));

    }

    public void Hide()
    {
        base.SetVisible(false);
    }
}
