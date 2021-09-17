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

    public void onBallPushed()
    {
        _hintText.enabled = false;
    }
}
