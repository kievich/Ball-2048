using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInput : MonoBehaviour
{
    private BallGun _ballGun;
    [SerializeField] private Trajectory _trajectory;
    [SerializeField] private float _sensitivity;

    private void Start()
    {
        _ballGun = GetComponent<BallGun>();
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            _trajectory.SetVisible(true);
        }

        if (Input.GetMouseButton(0) && _ballGun.IsBallOnSpawnPoint)
        {

            if (Input.GetAxis("Mouse X") != 0)
            {
                _trajectory.transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * _sensitivity, 0);
                _trajectory.UpdateTrajectoryLenght();
            }

        }

        if (Input.GetMouseButtonUp(0) && _ballGun.IsBallOnSpawnPoint)
        {
            _ballGun.PushBall(_trajectory.GetDirection());

        }




    }
}
