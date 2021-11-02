using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Booster
{
    [SerializeField] private float _radius;
    [SerializeField] private float _autoExplosionTime;

    override protected void onCollisionWithBall(Ball ball)
    {
        Explosion();
    }

    private void Start()
    {
        base.State.StateChanged += OnStateChanged;
    }

    private void OnStateChanged(BoosterStates ballState)
    {
        if (ballState == BoosterStates.Normal)
            Invoke(nameof(Explosion), _autoExplosionTime);
    }

    private void Explosion()
    {
        var balls = Util.BallHelper.FindBallsInRadius(gameObject.transform.position, _radius, BallStates.Normal);

        foreach (var ball in balls)
        {
            Ball.Destroy(ball);
        }
        Destroy(gameObject);
        base.OnPerformed(BoosterType.Bomb);
    }

}
