using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpSystem : MonoBehaviour
{
    [Header("Pop Up")]
    [SerializeField] private BallCreatedPopUp _ballCreated;
    [SerializeField] private PopUp _freeBall;
    [SerializeField] private PopUp _lastBall;
    [SerializeField] private BallTextures _ballTextures;

    private void Start()
    {
        BallUnifier.BallUnited += onBallCreated;
        Doubler.Doubled += onBallCreated;
    }

    public void onBallCreated(int value)
    {
        if (isLastBall(value) == true)
        {
            _lastBall.SetVisible(true);
            return;
        }

        if (value > 4)
            _ballCreated.Show(value);



    }

    private bool isLastBall(int value)
    {
        return _ballTextures.material.Length - 1 <= value;
    }
}
