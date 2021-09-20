using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHint : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI _hintText;

    private void Start()
    {
        FindObjectOfType<BallGun>().BallPushed += onBallPushed;
    }

    public void onBallPushed(Ball ball)
    {
        _hintText.enabled = false;
    }
}
