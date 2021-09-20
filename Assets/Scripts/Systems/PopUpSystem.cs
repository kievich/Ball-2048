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

    private void onBallCreated(Ball ball)
    {
        int value = ball.Value;

        if (ball.IsLast == true)
        {
            _lastBall.SetVisible(true);
            return;
        }

        if (value > 0)
        {
            //_ballCreated.Show(value);

        }
    }

    private void OnDestroy()
    {
        BallUnifier.BallUnited -= onBallCreated;
        Doubler.Doubled -= onBallCreated;
    }
}
