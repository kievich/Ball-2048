using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Util;

public class AddBusterPopUp : PopUp
{
    [SerializeField] private BusterSprites _rewardSprites;
    [SerializeField] private RawImage _BusterImage;

    public void Show(string busterType)
    {
        BoosterType buster = EnumHelper.ToEnum<BoosterType>(busterType);

        _BusterImage.texture = _rewardSprites.GetSprite(buster);

        base.SetVisible(true);

        gameObject.GetComponentInChildren<RewardedButton>().SetReward(Util.Converter.BusterToReward(buster));

    }

    public void Hide()
    {
        base.SetVisible(false);
    }
}
