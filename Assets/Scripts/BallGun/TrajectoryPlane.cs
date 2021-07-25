using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryPlane : MonoBehaviour
{

    [SerializeField] private int _numberOfSamples;
    private Renderer _trajectoryRenderer;
    private float _trajectoryLenght;

    public int NumberOfSamples => _numberOfSamples;
    public float TrajectoryLenght => _trajectoryLenght;

    private void Awake()
    {
        _trajectoryLenght = GetComponent<MeshFilter>().sharedMesh.bounds.size.z;
        _trajectoryRenderer = GetComponent<Renderer>();
    }


    public void SetLenght(int lenght)
    {
        if (lenght > _numberOfSamples || lenght < 1)
            throw new System.Exception("Out of Range, Lenght = " + lenght);

        float coefficient = (float)lenght / (float)_numberOfSamples;
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, coefficient);
        _trajectoryRenderer.material.mainTextureScale = new Vector2(1, coefficient);
        transform.localPosition = new Vector3(0, 0, -_trajectoryLenght * coefficient * 0.5f);
    }

}
