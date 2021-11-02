using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpSystem : MonoBehaviour
{
    [SerializeField] private BallCreatedPopUp _ballCreated;
    [SerializeField] private PopUp _freeBall;
    [SerializeField] private PopUp _lastBall;
    [SerializeField] private BallTextures _ballTextures;
    [SerializeField] private float _delayBeforeShowPopUp;

    private int _currentBallCreatedId;
    private int _numberUnitesFromLastPopUp = 0;
    private IEnumerator _showPopUpCoroutine;

    private void Start()
    {
        BallUnifier.BallUnited += onBallCreated;
        Doubler.Doubled += onBallCreated;
    }

    private void OnDestroy()
    {
        BallUnifier.BallUnited -= onBallCreated;
        Doubler.Doubled -= onBallCreated;
    }
    private void onBallCreated(Ball ball)
    {
        _numberUnitesFromLastPopUp++;
        int value = ball.Value;

        if (ball.IsLast == true)
            _lastBall.SetVisible(true);
        else if (value == 6 && _numberUnitesFromLastPopUp > 8)
            StartShowPopUpCoroutine(value);
        else if (value > 6)
            StartShowPopUpCoroutine(value);
    }

    private void StartShowPopUpCoroutine(int value)
    {
        if (value > _currentBallCreatedId)
            _currentBallCreatedId = value;

        if (_showPopUpCoroutine != null)
            StopCoroutine(_showPopUpCoroutine);

        _showPopUpCoroutine = ShowPopUp();
        StartCoroutine(_showPopUpCoroutine);
    }

    IEnumerator ShowPopUp()
    {
        yield return new WaitForSeconds(_delayBeforeShowPopUp);
        _ballCreated.Show(_currentBallCreatedId);
        _numberUnitesFromLastPopUp = 0;
        _currentBallCreatedId = 0;
    }
}
