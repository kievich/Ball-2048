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
        Ball ball = Ball.Create(_template, _ballCluster, _spawnPoint.position, Quaternion.identity, Random.Range(0, 3));
        return ball;
    }

}
