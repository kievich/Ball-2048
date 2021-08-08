using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doubler : Booster
{
    static public event Action<int> Doubled;

    protected override void onCollisionWithBall(Ball ball)
    {
        Double(ball);
    }

    private void Double(Ball ball)
    {
        ball.IncreaseValue();
        Doubled?.Invoke(ball.Value);
        Destroy(gameObject);
    }
}
