using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doubler : Booster
{
    static public event Action<Ball> Doubled;

    protected override void onCollisionWithBall(Ball ball)
    {
        Double(ball);
    }

    private void Double(Ball ball)
    {
        if (ball.IsLast == false)
        {
            ball.IncreaseValue();
            Doubled?.Invoke(ball);
        }
        Destroy(gameObject);

        base.OnPerformed(BoosterType.Bomb);

    }
}
