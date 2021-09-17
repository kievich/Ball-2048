using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideForce : MonoBehaviour
{
    [SerializeField] private float _value;
    [SerializeField] private Vector3 _direction;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        _rigidbody.AddForce(_direction.normalized * _value, ForceMode.Acceleration);
    }


}
