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
    private BoosterSpawner _boosterSpawner;

    private Ball _currentBall = null;
    private Booster _currentBooster = null;
    public bool IsItemOnSpawnPoint { get; private set; } = false;

    public event Action<Ball> BallPushed;
    public event Action BoosterPushed;

    private void Start()
    {
        _ballSpawner = GetComponent<BallSpawner>();
        _boosterSpawner = GetComponent<BoosterSpawner>();
        SpawnBall();
        _trajectory.SetVisible(false);
    }

    public void PushItem(Vector3 direction)
    {
        if (_currentBall)
            PushBall(direction);
        if (_currentBooster)
            PushBooster(direction);
    }

    private void PushBall(Vector3 direction)
    {
        IsItemOnSpawnPoint = false;
        _currentBall.State.Set(BallStates.Pushed);
        _currentBall.GetComponent<Rigidbody>().AddForce(direction * _pushForce);
        BallPushed?.Invoke(_currentBall);
        _currentBall = null;
        Invoke(nameof(SpawnBall), _spawnDelay);
    }

    private void PushBooster(Vector3 direction)
    {
        IsItemOnSpawnPoint = false;
        _currentBooster.State.Set(BoosterStates.Normal);
        _currentBooster.GetComponent<Rigidbody>().AddForce(direction * _pushForce);
        _currentBooster = null;
        BoosterPushed?.Invoke();
        Invoke(nameof(SpawnBall), _spawnDelay);
    }

    public void SpawnBooster(BoosterType boosterType)
    {
        if (_currentBall != null)
            Ball.Destroy(_currentBall);

        IsItemOnSpawnPoint = true;

        _currentBall = null;
        _currentBooster = _boosterSpawner.SpawnBooster(boosterType);
    }

    private void SpawnBall()
    {
        _currentBall = _ballSpawner.SpawnBall();
        IsItemOnSpawnPoint = true;
    }


}
