using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionDetection : MonoBehaviour
{
    private BallUnifier _ballUnifier;
    private Ball _ball;

    private void Start()
    {
        _ballUnifier = FindObjectOfType<BallUnifier>();
        _ball = GetComponent<Ball>();
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.TryGetComponent<Ball>(out Ball ball))
        {

            if (_ball.Id < ball.Id)
            {
                _ballUnifier.DoUnite(_ball, ball);
            }

        }
    }

}
