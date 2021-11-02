using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    [SerializeField] private PopUp _losePopUp;
    [SerializeField] private BallGun _ballGun;
    [SerializeField] private float _timeInColiderBeforeLose;

    private bool _isLose = false;
    public event Action Lose;

    private void Start()
    {
        _ballGun.BallPushed += onBallPushed;
    }

    private void onDisable()
    {
        _ballGun.BallPushed -= onBallPushed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Ball>(out Ball ball))
            if (ball.State.Value == BallStates.Normal && _isLose == false)
                DoLose();

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Ball>(out Ball ball))
            if (ball.State.Value == BallStates.Pushed)
                ball.State.Set(BallStates.Normal);
    }

    private void onBallPushed(Ball ball)
    {
        StartCoroutine(CheckBallStatus(ball));
    }

    public void Reset()
    {
        _isLose = false;
    }

    private IEnumerator CheckBallStatus(Ball ball)
    {
        yield return new WaitForSeconds(_timeInColiderBeforeLose);
        if (ball.State.Value == BallStates.Pushed)
            DoLose();

    }

    private void DoLose()
    {
        Lose?.Invoke();
        _isLose = true;
        AppData.SetShouldBeRestarted(true);
        _losePopUp.SetVisible(true);
    }
}
