using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallUnifier : MonoBehaviour
{
    [SerializeField] private BallTextures _balltextures;
    private int _maxBallValue;

    private void Start()
    {
        _maxBallValue = _balltextures.material.Length - 1;
    }

    public void DoUnite(Ball sender, Ball crashedBall)
    {
        if (sender.Value == crashedBall.Value && sender.Value != _maxBallValue)
        {
            sender.IncreaseValue();
            sender.GetComponent<Rigidbody>().AddForce(Vector3.up * 200f);
            Destroy(crashedBall.gameObject);
        }

    }
}
