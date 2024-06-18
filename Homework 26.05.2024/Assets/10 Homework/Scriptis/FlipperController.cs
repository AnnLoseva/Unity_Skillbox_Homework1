using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperController : MonoBehaviour
{
    [SerializeField] private HingeJoint leftFlipper;
    [SerializeField] private HingeJoint rightFlipper;
    [SerializeField] private float hitPower = 10000f;
    [SerializeField] private float restTarget = 0f;
    [SerializeField] private float pressedTarget = 45f;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    private bool leftAudioOn;
    private bool rightAudioOn;


    private void Start()
    {
        audioSource.clip = audioClip;
    }

    private void Update()
    {
        JointSpring leftJointSpring = new JointSpring();
        JointSpring rightJointSpring = new JointSpring();
        leftJointSpring.spring = hitPower;
        leftJointSpring.damper = 150f;
        rightJointSpring.spring = hitPower;
        rightJointSpring.damper = 150f;

        if(Input.GetKey(KeyCode.LeftArrow)) 
        {

            leftJointSpring.targetPosition = pressedTarget;
            if (!leftAudioOn)
            {
                audioSource.Play();
                leftAudioOn = true;
            }

        }
        else
        {
            leftJointSpring.targetPosition = restTarget;
            leftAudioOn = false;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {

            rightJointSpring.targetPosition = pressedTarget;
            if (!rightAudioOn)
            {
                audioSource.Play();
                rightAudioOn = true;
            }
        }
        else
        {
            rightJointSpring.targetPosition = restTarget;
            rightAudioOn = false;
        }

        leftFlipper.spring = leftJointSpring;
        rightFlipper.spring = rightJointSpring;
        leftFlipper.useLimits= true;
        rightFlipper.useLimits= true;
    }


}
