using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private HingeJoint[] wheels;

    [SerializeField] private float speed = 300;
    [SerializeField] private float turnDegree = 45;
    [SerializeField] private float motorForce = 100;

    private float forwardAxis;
    private float turnAxis;

    private void Update()
    {
        ForwardBackward();
        //Turn();
    }

    private void ForwardBackward()
    {

        forwardAxis = Input.GetAxis("Vertical");

        foreach(HingeJoint wheel in wheels)
        {
            JointMotor motor = wheel.motor;
            motor.force = motorForce;
            motor.targetVelocity = forwardAxis * speed;
            wheel.motor = motor;
            wheel.useMotor = true;
        }

    }


    // Ќе понимаю, как нормально сделать поворот...
    private void Turn()
    {
        turnAxis = Input.GetAxis("Horizontal");

        Quaternion targetRotation = Quaternion.Euler(wheels[0].gameObject.transform.rotation.x, turnAxis * turnDegree, wheels[0].gameObject.transform.rotation.z);

        wheels[0].gameObject.transform.rotation = Quaternion.Lerp(wheels[0].gameObject.transform.rotation, targetRotation, 10 * Time.deltaTime);
    }
}
