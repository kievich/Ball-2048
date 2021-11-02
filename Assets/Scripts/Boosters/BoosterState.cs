using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterState : MonoBehaviour
{
    public BoosterStates Value { get; private set; } = BoosterStates.OnSpawnPoint;
    private Rigidbody _rigidbody;

    public event System.Action<BoosterStates> StateChanged;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    public void Set(BoosterStates state)
    {

        if (state == BoosterStates.OnSpawnPoint)
        {
            _rigidbody.isKinematic = true;
        }

        if (state == BoosterStates.Normal)
        {
            _rigidbody.isKinematic = false;
        }

        Value = state;
        StateChanged?.Invoke(Value);
    }
}
