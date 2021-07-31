using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallParamentsChanger : MonoBehaviour
{

    [SerializeField] private float _newbieLifetime;
    [SerializeField] private PhysicMaterial _oldPhysicMaterial;

    private Ball _ball;
    private BallGun _ballGun;
    private void Start()
    {
        _ball = GetComponent<Ball>();
        _ballGun = FindObjectOfType<BallGun>();
        _ballGun.BallPushed += onBallPushed;
    }

    private void OnDisable()
    {
        _ballGun.BallPushed -= onBallPushed;
    }

    private void onBallPushed()
    {
        Invoke(nameof(SetParameters), _newbieLifetime);
    }
    private void SetParameters()
    {
        if (TryGetComponent<Collider>(out Collider collider))
        {
            _ballGun.BallPushed -= onBallPushed;
            collider.material = _oldPhysicMaterial;
            _ball.SetOldStatus();

        }

    }

}
