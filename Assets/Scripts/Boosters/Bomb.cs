using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Booster
{
    [SerializeField] private float _radius;
    [SerializeField] private float _autoExplosiontTime;

    override protected void onCollisionWithBall(Ball ball)
    {
        Explosion();
    }

    private void Start()
    {
        Invoke(nameof(Explosion), _autoExplosiontTime);
    }

    private void Explosion()
    {
        var balls = Util.BallHelper.FindBallsInRadius(gameObject.transform.position, _radius,BallStates.Normal);

        foreach (var ball in balls)
        {
            Ball.Destroy(ball);
        }
        Destroy(gameObject);
    }

}
