using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInput : MonoBehaviour
{
    private BallGun _ballGun;
    [SerializeField] private Trajectory _trajectory;
    [SerializeField] private float _sensitivity;
    [SerializeField] private float _touchSensitivity;

    private void Start()
    {
        _ballGun = GetComponent<BallGun>();
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0) && _ballGun.IsBallOnSpawnPoint)
        {
            _trajectory.SetVisible(true);
        }

        if (Input.GetMouseButton(0) && _ballGun.IsBallOnSpawnPoint)
        {

            if (Input.GetAxis("Mouse X") != 0)
            {

                _trajectory.Rotate(Input.GetAxis("Mouse X") * _sensitivity);
                _trajectory.UpdateTrajectoryLenght();
            }

        }

        if (Input.touchCount > 0 && _ballGun.IsBallOnSpawnPoint)
        {
            Touch touch = Input.touches[0];
            if (touch.phase == TouchPhase.Moved)
            {
                _trajectory.Rotate(touch.deltaPosition.x * _touchSensitivity);
                _trajectory.UpdateTrajectoryLenght();
            }
        }


        if (Input.GetMouseButtonUp(0) && _ballGun.IsBallOnSpawnPoint)
        {
            _ballGun.PushBall(_trajectory.GetDirection());
            _trajectory.ResetRotation();
        }





    }
}
