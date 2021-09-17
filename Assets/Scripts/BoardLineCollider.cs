using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardLineCollider : MonoBehaviour
{
    private bool _isLose = false;

    public event Action Lose;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Ball>(out Ball ball))
        {
            if (ball.State.Value == BallStates.Normal && _isLose == false)
            {
                Lose?.Invoke();
                _isLose = true;
                Debug.Log("Lose");
            }

            if (ball.State.Value == BallStates.Pushed)
            {
                ball.State.Set(BallStates.Normal);
            }
        }

    }
}
