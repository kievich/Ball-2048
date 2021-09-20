using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelContinue : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _deleteRadius;
    [SerializeField] private LoseCollider _loseCollider;
    public void Continue()
    {
        List<Ball> balls = Util.BallHelper.FindBallsInRadius(_spawnPoint.position, _deleteRadius, BallStates.Normal);
        foreach (var ball in balls)
        {
            Ball.Destroy(ball);
        }
        AppData.SetShouldBeRestarted(false);

        _loseCollider.Reset();
    }
}
