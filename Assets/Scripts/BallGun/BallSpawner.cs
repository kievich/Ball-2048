using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Ball _template;
    [SerializeField] private Transform _ballCluster;

    public Ball SpawnBall()
    {
        Ball ball = Ball.Create(_template, _ballCluster, _spawnPoint.position, Quaternion.identity, SelectRandomValue());
        return ball;
    }

    private int SelectRandomValue()
    {
        int random = Random.Range(1, 100);

        if (random < 30)
            return 0;
        if (random < 60)
            return 1;
        if (random < 85)
            return 2;
        if (random < 95)
            return 3;
        if (random < 97)
            return 4;

        return 5;

    }

}
