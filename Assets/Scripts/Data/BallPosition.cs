using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BallPosition
{
    public Vector3 Position;
    public Vector3 Rotation;
    public int Value;


    public BallPosition(Vector3 position, Vector3 rotation, int value)
    {
        Position = position;
        Rotation = rotation;
        Value = value;
    }
}
