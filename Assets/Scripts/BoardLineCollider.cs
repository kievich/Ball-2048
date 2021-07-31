using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardLineCollider : MonoBehaviour
{
    private bool isLose = false;

    public event Action Lose;

    private void OnTriggerStay(Collider other)
    {

        if (other.TryGetComponent<Ball>(out Ball ball))
        {
            if (ball.Status == BallStatus.Old && isLose == false)
            {
                Lose?.Invoke();
                isLose = true;
                Debug.Log("Lose");
            }
        }
    }
}
