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
        Time.timeScale = 0;

        Pause?.Invoke();
        IsPause = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        Resume?.Invoke();
        IsPause = false;
    }
}
