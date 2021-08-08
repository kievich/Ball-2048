using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPause : MonoBehaviour
{
    public List<Rigidbody> _rigidbodies;
    public List<Vector3> _rigidbodyVelocity;
    public void PauseGame()
    {
        _rigidbodies.Clear();
        _rigidbodyVelocity.Clear();

        foreach (var ball in Ball.balls)
        {
            Rigidbody rigidbody = ball.GetComponent<Rigidbody>();
            _rigidbodyVelocity.Add(rigidbody.velocity);
            rigidbody.Sleep();
            _rigidbodies.Add(rigidbody);
        }
    }

    public void ResumeGame()
    {
        for (var i = 0; i < _rigidbodies.Count; i++)
        {
            _rigidbodies[i].WakeUp();
            _rigidbodies[i].velocity = _rigidbodyVelocity[i];
        }

    }
}


