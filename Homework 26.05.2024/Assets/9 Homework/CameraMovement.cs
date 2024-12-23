using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform[] cameraPoints;
    public float speed;
    public GameObject dice;
    public GameObject superman;
    public GameObject billiard;
    public GameObject zeroGravity;

    private Transform currentPoint;

    private void Start()
    {
        transform.position = cameraPoints[0].position;

        currentPoint = transform;   
    }
    void Update()
    {
         transform.SetPositionAndRotation(Vector3.Lerp(transform.position, currentPoint.position, speed * Time.deltaTime), Quaternion.Lerp(transform.rotation, currentPoint.rotation, speed * Time.deltaTime));
    }

    public void ChangePoint1()
    {
        currentPoint = cameraPoints[0];

        dice.SetActive(true);
        superman.SetActive(false);
        billiard.SetActive(false);
        zeroGravity.SetActive(false);
    }

    public void ChangePoint2()
    {
        currentPoint = cameraPoints[1];

        dice.SetActive(false);
        superman.SetActive(true);
        billiard.SetActive(false);
        zeroGravity.SetActive(false);
    }

    public void ChangePoint3()
    {
        currentPoint = cameraPoints[2];
        dice.SetActive(false);
        superman.SetActive(false);
        billiard.SetActive(true);
        zeroGravity.SetActive(false);
    }

    public void ChangePoint4()
    {
        currentPoint = cameraPoints[3];

        dice.SetActive(false);
        superman.SetActive(false);
        billiard.SetActive(false);
        zeroGravity.SetActive(true);
    }

}
