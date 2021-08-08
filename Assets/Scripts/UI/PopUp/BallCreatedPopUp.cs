using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallCreatedPopUp : PopUp
{
    [Header("Ball Created PopUp")]
    [SerializeField] private BallTextures _ballTextures;
    [SerializeField] private RawImage _ballImage;


    public void Show(int value)
    {
        _ballImage.texture = _ballTextures.material[value].mainTexture;
        base.SetVisible(true);
    }

    public void Hide()
    {
        base.SetVisible(false);
    }


}
