using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallInput : MonoBehaviour
{
    private BallGun _ballGun;
    [SerializeField] private Trajectory _trajectory;
    [SerializeField] private float _sensitivity;
    [SerializeField] private float _touchSensitivity;
    private bool _isMoving = false;

    private void Start()
    {
        _ballGun = GetComponent<BallGun>();
    }

    private void Update()
    {
#if UNITY_EDITOR
        EditorInput();
#endif

#if UNITY_ANDROID
        PhoneInput();
#endif
    }

    private void EditorInput()
    {
        if (Input.GetMouseButtonDown(0) && _ballGun.IsItemOnSpawnPoint && !EventSystem.current.IsPointerOverGameObject())
            _trajectory.SetVisible(true);

        if (Input.GetMouseButton(0) && _ballGun.IsItemOnSpawnPoint && !EventSystem.current.IsPointerOverGameObject())
            if (Input.GetAxis("Mouse X") != 0)
            {
                _trajectory.Rotate(Input.GetAxis("Mouse X") * _sensitivity);
                _trajectory.UpdateTrajectoryLenght();
            }

        if (Input.GetMouseButtonUp(0) && _ballGun.IsItemOnSpawnPoint && !EventSystem.current.IsPointerOverGameObject())
        {
            _ballGun.PushItem(_trajectory.GetDirection());
            _trajectory.SetVisible(false);
            _trajectory.ResetRotation();
        }
    }

    private void PhoneInput()
    {

        if (Input.touchCount > 0 && _ballGun.IsItemOnSpawnPoint && !EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId))
        {
            Touch touch = Input.touches[0];
            Vibration.NativeVibration.Vibrate(100);
            if (touch.phase == TouchPhase.Began)
            {
                _trajectory.ResetRotation();
                _trajectory.SetVisible(true);
                _isMoving = true;
            }

            if (touch.phase == TouchPhase.Moved)
            {
                _trajectory.Rotate(touch.deltaPosition.x * _touchSensitivity);
                _trajectory.UpdateTrajectoryLenght();
            }

            if (touch.phase == TouchPhase.Ended && _isMoving)
            {
                _ballGun.PushItem(_trajectory.GetDirection());
                _trajectory.SetVisible(false);
                _isMoving = false;
            }
        }
    }
}
