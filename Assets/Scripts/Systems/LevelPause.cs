using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelPause : MonoBehaviour
{
    private List<Ball> _balls = new List<Ball>();
    private List<Vector3> _velocity = new List<Vector3>();
    public static event Action Pause;
    public static event Action Resume;
    public static bool IsPause { get; private set; }

    private void Start()
    {
        IsPause = false;
    }
    public void PauseGame()
    {
        _velocity.Clear();
        _balls.Clear();
        //foreach (var ball in Ball.balls)
        //{
        //    _balls.Add(ball);
        //    _velocity.Add(ball.Rigidbody.velocity);
        //    ball.Rigidbody.Sleep();
        //    ball.SideForce.Enable = false;
        //}
        Time.timeScale = 0;

        Pause?.Invoke();
        IsPause = true;
    }

    public void ResumeGame()
    {
        //for (var i = 0; i < _balls.Count; i++)
        //{
        //    _balls[i].Rigidbody.WakeUp();
        //    _balls[i].SideForce.Enable = true;
        //    _balls[i].Rigidbody.velocity = _velocity[i];
        //}

        Time.timeScale = 1;


        Resume?.Invoke();
        IsPause = false;
    }
}


