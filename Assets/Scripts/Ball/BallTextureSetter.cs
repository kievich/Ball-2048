using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTextureSetter : MonoBehaviour
{
    [SerializeField] private BallTextures _ballTextures;
    public void SetTexture(int ballValue)
    {
        int lenght = _ballTextures.material.Length;

        if (lenght - 1 < ballValue)
            gameObject.GetComponent<Renderer>().material = _ballTextures.material[lenght - 1];
        else
            gameObject.GetComponent<Renderer>().material = _ballTextures.material[ballValue];

    }


    public bool IsLastBall(int value)
    {
        return _ballTextures.material.Length - 1 <= value;
    }
}
