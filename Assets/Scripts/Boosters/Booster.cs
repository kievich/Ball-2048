using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Booster : MonoBehaviour
{
    protected abstract void onCollisionWithBall(Ball ball);

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Ball>(out Ball ball))
            onCollisionWithBall(ball);
    }



}

