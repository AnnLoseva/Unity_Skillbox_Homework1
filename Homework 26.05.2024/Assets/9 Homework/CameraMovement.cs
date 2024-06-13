using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraChanger : MonoBehaviour
{
    public Transform[] cameraPoints;
    public float speed;

    private Transform currentPoint;

    private void Start()
    {
        currentPoint = transform;
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentPoint.position, speed*Time.deltaTime);
    }

    public void ChangePoint1()
    {
        currentPoint = cameraPoints[0];
    }

    public void ChangePoint2()
    {
        currentPoint = cameraPoints[1];
    }

    public void ChangePoint3()
    {
        currentPoint = cameraPoints[2];
    }

    public void ChangePoint4()
    {
        currentPoint = cameraPoints[3];
    }

}
