using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallContainer
{

    public List<BallPosition> BallPositions;

    public void FillUp()
    {
        BallPositions = new List<BallPosition>();

        foreach (var ball in Ball.balls)
        {
            if (ball.State.Value == BallStates.Normal)
            {
                Transform ballTranform = ball.gameObject.transform;
                BallPositions.Add(new BallPosition(ballTranform.position, ballTranform.rotation.eulerAngles, ball.Value));
            }
        }
    }
}
