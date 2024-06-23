using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider backRight;
    [SerializeField] WheelCollider backLeft;

    [SerializeField] private float acceleration = 500f;
    [SerializeField] private float breakingForce = 300f;
    [SerializeField] private float maxTurnAngle = 15f;

    private float currentAcceleration = 0f;
    private float currentBreakingForce = 0f;
    private float currentTurnAngle = 0f;

    private float forwardAxis;
    private float turnAxis;

    private void Update()
    {
        ForwardBackward();
        Turn();
        Break();
    }

    private void ForwardBackward()
    {

        forwardAxis = Input.GetAxis("Vertical");

        currentAcceleration = acceleration * forwardAxis;

        backRight.motorTorque = currentAcceleration;
        backLeft.motorTorque = currentAcceleration;
    }

    private void Turn()
    {
        turnAxis = Input.GetAxis("Horizontal");
        currentTurnAngle = maxTurnAngle * turnAxis;

        Debug.Log(currentTurnAngle);

        frontLeft.steerAngle = currentTurnAngle;
        frontRight.steerAngle = currentTurnAngle;

    }

    private void Break()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            currentBreakingForce = breakingForce;
        }
        else
        {
            {
                currentBreakingForce = 0f;
            }
        }

        backLeft.brakeTorque = currentBreakingForce;
        backRight.brakeTorque = currentBreakingForce;
        frontLeft.brakeTorque = currentBreakingForce;
        frontRight.brakeTorque = currentBreakingForce;

    }
}
