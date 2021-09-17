using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallUnifier : MonoBehaviour
{
    [SerializeField] private BallTextures _balltextures;
    [SerializeField] float _bounceVelocity;
    [SerializeField] float _maxcorrectiveDistance;
    [SerializeField] float _maxcorrectiveVelocity;

    private int _maxBallValue;
    private const float gForce = 9.8f;

    public static event Action<Ball> BallUnited;

    private void Start()
    {
        _maxBallValue = _balltextures.material.Length - 1;
    }

    public void DoUnite(Ball sender, Ball crashedBall)
    {
        if (LevelPause.IsPause || sender.State.Value != BallStates.Normal || crashedBall.State.Value != BallStates.Normal)
            return;

        if (sender.Value == crashedBall.Value && sender.Value != _maxBallValue)
        {
            sender.IncreaseValue();
            ApplyUniteBounce(sender);
            Ball.Destroy(crashedBall);
            BallUnited?.Invoke(sender);
        }

    }

    private void ApplyUniteBounce(Ball ball)
    {
        Ball nearestBall = FindNearestBall(ball);
        Vector3 correctiveDirection;
        float correctiveDistance;
        Rigidbody rigidbody = ball.GetComponent<Rigidbody>();

        if (nearestBall != ball)
        {
            correctiveDirection = new Vector3(nearestBall.transform.position.x - ball.transform.position.x, 0, nearestBall.transform.position.z - ball.transform.position.z).normalized;

            correctiveDistance = Mathf.Sqrt(
                Mathf.Pow((nearestBall.transform.position.x - ball.transform.position.x), 2) +
                Mathf.Pow((nearestBall.transform.position.z - ball.transform.position.z), 2));
        }
        else
        {
            correctiveDirection = Vector3.zero;
            correctiveDistance = 0;
        }

        rigidbody.velocity = FindCorrectiveVelocity(correctiveDistance, correctiveDirection);

    }


    private Ball FindNearestBall(Ball targetBall)
    {
        Ball bearestBall = targetBall;
        float minimumDistance = float.MaxValue;

        Vector2 targetPosition = new Vector2(targetBall.transform.position.x, targetBall.transform.position.z);

        foreach (Ball ball in Ball.balls)
        {

            float distanceWithoutSqrt = Mathf.Pow((targetPosition.x - ball.transform.position.x), 2) +
                                        Mathf.Pow((targetPosition.y - ball.transform.position.z), 2);

            if (distanceWithoutSqrt < minimumDistance && ball != targetBall && ball.Value == targetBall.Value)
            {
                bearestBall = ball;
                minimumDistance = distanceWithoutSqrt;
            }
        }

        return bearestBall;
    }

    private Vector3 FindCorrectiveVelocity(float distance, Vector3 direction)
    {
        float bounceTime = _bounceVelocity / gForce * 2;
        float correctiveVelocityValue = distance / bounceTime;

        if (correctiveVelocityValue > _maxcorrectiveVelocity)
            correctiveVelocityValue = _maxcorrectiveVelocity;

        if (distance > _maxcorrectiveDistance)
            correctiveVelocityValue = 0;

        return Vector3.up * _bounceVelocity + direction * correctiveVelocityValue;
    }

}
