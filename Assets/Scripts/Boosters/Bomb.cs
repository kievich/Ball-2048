using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Booster
{
    [SerializeField] private float _radius;

    override protected void onCollisionWithBall(Ball ball)
    {

        Explosion();
    }

    private void Explosion()
    {
        var balls = FindBallsInRadius();

        foreach (var ball in balls)
        {
            Ball.Destroy(ball);
        }
        Destroy(gameObject);
    }

    private List<Ball> FindBallsInRadius()
    {
        List<Ball> balls = new List<Ball>();
        Vector3 position = gameObject.transform.position;

        foreach (var ball in Ball.balls)
        {
            if (Vector3.Distance(position, ball.gameObject.transform.position) < _radius && ball.Status == BallStatus.Old)
                balls.Add(ball);

        }
        return balls;

    }

}
