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
    [SerializeField] private RawImage _busterImage;
    [SerializeField] private BusterSprites _rewardSprites;

    private BoosterType _buster;

    public void Show(int value)
    {
        SetBusterType();
        _ballImage.texture = _ballTextures.material[value].mainTexture;
        _ballValue.text = Util.Converter.BallValueToRealValue(value).ToString();
        _busterImage.texture = _rewardSprites.GetSprite(_buster);

        base.SetVisible(true);

        gameObject.GetComponentInChildren<RewardedButton>().SetReward(Util.Converter.BusterToReward(_buster));
    }

    public void Hide()
    {
        base.SetVisible(false);
    }

    private void SetBusterType()
    {
        var busterCount = Enum.GetNames(typeof(BoosterType)).Length;
        _buster = (BoosterType)UnityEngine.Random.Range(0, busterCount);
    }
}
