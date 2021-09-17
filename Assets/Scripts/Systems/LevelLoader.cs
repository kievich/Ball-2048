using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Ball _ballTemplate;
    [SerializeField] private Transform _ballCluster;

    private void Start()
    {
        var container = AppData.LoadBallPosition();
        if (container.BallPositions != null)
        {
            foreach (var ball in container.BallPositions)
            {
                Ball.Create(_ballTemplate, _ballCluster, ball.Position, Quaternion.Euler(ball.Rotation), ball.Value)
                    .State.Set(BallStates.Normal);
            }
        }


    }
}
