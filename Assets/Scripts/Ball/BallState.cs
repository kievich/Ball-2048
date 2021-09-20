using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallState : MonoBehaviour
{
    public BallStates Value { get; private set; } = BallStates.OnSpawnPoint;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    public void Set(BallStates state)
    {

        if (state == BallStates.OnSpawnPoint)
        {
            _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }

        if (state == BallStates.Pushed || state == BallStates.Normal)
        {
            _rigidbody.constraints = RigidbodyConstraints.None;
        }

        Value = state;

    }


}
