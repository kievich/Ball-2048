using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoosterState))]
public abstract class Booster : MonoBehaviour
{
    public BoosterState State { get; private set; }

    protected abstract void onCollisionWithBall(Ball ball);

    private void Awake()
    {
        State = GetComponent<BoosterState>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Ball>(out Ball ball))
            onCollisionWithBall(ball);
    }



}

