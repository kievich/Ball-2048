using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionDetection : MonoBehaviour
{
    private BallUnifier _ballUnifier;
    private Ball _ball;
    private bool isInit = false;

    private void Start()
    {
        isInit = true;
    }

    private void OnEnable()
    {
        _ball = GetComponent<Ball>();
        _ballUnifier = FindObjectOfType<BallUnifier>();

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.TryGetComponent<Ball>(out Ball ball) && isInit)
        {
            if (_ball.Id < ball.Id)
            {
                _ballUnifier.DoUnite(_ball, ball);
            }
        }
    }

}
