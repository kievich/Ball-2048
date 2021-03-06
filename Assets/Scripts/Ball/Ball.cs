using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BallTextures))]
[RequireComponent(typeof(BallCollisionDetection))]
[RequireComponent(typeof(BallState))]
public class Ball : MonoBehaviour
{

    private static int NumberOfBalls = 0;
    public static List<Ball> balls { get; private set; } = new List<Ball>();
    public int Id { get; private set; }
    public int Value { get; private set; }
    public BallState State { get; private set; }
    public SideForce SideForce { get; private set; }
    public Rigidbody Rigidbody { get; private set; }
    private BallTextureSetter _ballTextureSetter;
    public bool IsLast => _ballTextureSetter.IsLastBall(Value);

    private void OnEnable()
    {
        Id = NumberOfBalls;
        NumberOfBalls++;
        _ballTextureSetter = GetComponent<BallTextureSetter>();

        State = GetComponent<BallState>();
        SideForce = GetComponent<SideForce>();
        Rigidbody = GetComponent<Rigidbody>();
    }

    public static Ball Create(Ball template, Transform parent, Vector3 position, Quaternion quaternion, int value)
    {
        Ball ball = Instantiate(template, position, quaternion, parent);
        ball.GetComponent<BallTextureSetter>().SetTexture(value);
        ball.Value = value;
        ball.State.Set(BallStates.OnSpawnPoint);
        balls.Add(ball);
        return ball;
    }

    public static void Destroy(Ball ball)
    {
        balls.Remove(ball);
        Destroy(ball.gameObject);
    }

    public static void DestroyAll()
    {
        while (balls.Count > 0)
        {
            Destroy(balls[0]);

        }
    }

    public void IncreaseValue()
    {
        Value++;
        _ballTextureSetter.SetTexture(Value);
    }

}
