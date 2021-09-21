using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    [SerializeField] private float _maxEuler;
    private TrajectoryPlane _trajectoryPlane;
    private float _sampleLenght;
    private Renderer _renderer;


    private void Start()
    {
        _trajectoryPlane = GetComponentInChildren<TrajectoryPlane>();
        _renderer = GetComponentInChildren<Renderer>();
        _sampleLenght = _trajectoryPlane.TrajectoryLenght / _trajectoryPlane.NumberOfSamples;
    }

    public Vector3 GetDirection()
    {
        return (_trajectoryPlane.transform.position - gameObject.transform.position).normalized;
    }

    public void UpdateTrajectoryLenght()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, GetDirection(), out hit, Mathf.Infinity))
            _trajectoryPlane.SetLenght(DistanceToPlaneLenght(hit.distance));

    }

    private int DistanceToPlaneLenght(float distance)
    {

        int numberOfSamples = (int)(distance / _sampleLenght);

        if (numberOfSamples < 1)
            numberOfSamples = 1;

        if (numberOfSamples > 20)
            numberOfSamples = 20;

        return numberOfSamples;
    }

    public void SetVisible(bool visible)
    {
        _renderer.enabled = visible;
        UpdateTrajectoryLenght();
    }

    public void Rotate(float inputValue)
    {
        float y = transform.rotation.eulerAngles.y;
        y += inputValue;
        if (y > 180)
            y -= 360;

        y = Mathf.Clamp(y, -_maxEuler, _maxEuler);
        transform.rotation = Quaternion.Euler(0, y, 0);
    }

    public void ResetRotation()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

}
