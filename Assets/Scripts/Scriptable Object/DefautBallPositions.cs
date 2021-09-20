using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/DefautBallPositions", fileName = "DefautBallPositions")]
public class DefautBallPositions : ScriptableObject
{
    [SerializeField] private string[] _jsonPositions;

    public string GetRandomJsonPosition()
    {
        return _jsonPositions[Random.Range(0, _jsonPositions.Length - 1)];
    }
}
