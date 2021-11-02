using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHint : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI _hintText;

    private BallGun _ballGun;

    private void Start()
    {
        _ballGun = FindObjectOfType<BallGun>();
        _ballGun.BallPushed += onBallPushed;
    }

    private void OnDestroy()
    {
        _ballGun.BallPushed -= onBallPushed;
    }


    public void onBallPushed(Ball ball)
    {
        _hintText.enabled = false;
    }
}
