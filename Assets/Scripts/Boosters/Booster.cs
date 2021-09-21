using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoosterState))]
public abstract class Booster : MonoBehaviour
{
    public BoosterState State { get; private set; }
    public static event Action<BoosterType> Performed;

    protected abstract void onCollisionWithBall(Ball ball);

    private void Awake()
    {
        State = GetComponent<BoosterState>();
    }

    protected void OnPerformed(BoosterType boosterType)
    {
        Performed?.Invoke(boosterType);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Ball>(out Ball ball))
            onCollisionWithBall(ball);
    }



}

