using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BallTextures))]
[RequireComponent(typeof(BallCollisionDetection))]
public class Ball : MonoBehaviour
{

    private static int NumberOfBalls = 0;
    public static List<Ball> balls { get; private set; } = new List<Ball>();
    public int Id { get; private set; }
    public int Value { get; private set; }
    public BallStatus Status { get; private set; } = BallStatus.Newbie;

    private BallTextureSetter _ballTextureSetter;

    private void OnEnable()
    {
        Id = NumberOfBalls;
        NumberOfBalls++;
        _ballTextureSetter = GetComponent<BallTextureSetter>();

    }

    public static Ball Create(Ball template, Transform parent, Vector3 position, Quaternion quaternion, int value)
    {
        Ball ball = Instantiate(template, position, quaternion, parent);
        ball.GetComponent<BallTextureSetter>().SetTexture(value);
        ball.Value = value;
        balls.Add(ball);
        return ball;
    }

    public static void Destroy(Ball ball)
    {
        balls.Remove(ball);
        Destroy(ball.gameObject);
    }

    public void SetOldStatus()
    {
        Status = BallStatus.Old;
    }

    public void IncreaseValue()
    {
        Value++;
        _ballTextureSetter.SetTexture(Value);
    }

}
