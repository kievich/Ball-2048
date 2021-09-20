using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Ball _ballTemplate;
    [SerializeField] private Transform _ballCluster;
    [SerializeField] private DefautBallPositions _defautPositions;
    private void Start()
    {
        if (AppData.ShouldBeRestarted)
        {
            AppData.ResetScore();
            AppData.SetDefaultBallPosition(_defautPositions);
            AppData.SetShouldBeRestarted(false);
        }

        var container = AppData.LoadBallPosition(_defautPositions);

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
