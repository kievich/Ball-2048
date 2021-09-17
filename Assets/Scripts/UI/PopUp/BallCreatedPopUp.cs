using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallCreatedPopUp : PopUp
{
    [Header("Ball Created PopUp")]
    [SerializeField] private BallTextures _ballTextures;
    [SerializeField] private TMPro.TextMeshProUGUI _ballValue;
    [SerializeField] private RawImage _ballImage;
    [SerializeField] private RawImage _boosterImage;
    [SerializeField] private BoosterSprites _rewardSprites;

    private BoosterType _booster;

    public void Show(int value)
    {
        SetBoosterType();
        _ballImage.texture = _ballTextures.material[value].mainTexture;
        _ballValue.text = Util.Converter.BallValueToRealValue(value).ToString();
        _boosterImage.texture = _rewardSprites.GetSprite(_booster);

        base.SetVisible(true);

        gameObject.GetComponentInChildren<RewardedButton>().SetReward(Util.Converter.BoosterToReward(_booster));
    }

    public void Hide()
    {
        base.SetVisible(false);
    }

    private void SetBoosterType()
    {
        var boosterCount = Enum.GetNames(typeof(BoosterType)).Length;
        _booster = (BoosterType)UnityEngine.Random.Range(0, boosterCount);
    }
}
