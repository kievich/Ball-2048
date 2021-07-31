using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BallSpawner))]
[RequireComponent(typeof(BallInput))]
public class BallGun : MonoBehaviour
{

    [SerializeField] private float _pushForce;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private Trajectory _trajectory;

    private BallSpawner _ballSpawner;
    private Ball _currentBall;
    public bool IsBallOnSpawnPoint { get; private set; } = false;

    public event Action BallPushed;

    private void Start()
    {
        _ballSpawner = GetComponent<BallSpawner>();
        SpawnBall();
        _trajectory.SetVisible(false);

    }

    public void PushBall(Vector3 direction)
    {
        _trajectory.SetVisible(false);
        IsBallOnSpawnPoint = false;
        _currentBall.GetComponent<Rigidbody>().AddForce(direction * _pushForce);
        _currentBall = null;
        BallPushed?.Invoke();
        Invoke(nameof(SpawnBall), _spawnDelay);
    }

    private void SpawnBall()
    {
        _currentBall = _ballSpawner.SpawnBall();
        IsBallOnSpawnPoint = true;
    }

}
