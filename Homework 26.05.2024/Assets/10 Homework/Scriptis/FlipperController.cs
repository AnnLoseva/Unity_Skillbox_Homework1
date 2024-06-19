using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlipperController : MonoBehaviour
{
    [SerializeField] private HingeJoint leftFlipper;
    [SerializeField] private HingeJoint rightFlipper;
    [SerializeField] private float hitPower = 10000f;
    [SerializeField] private float restTarget = 0f;
    [SerializeField] private float pressedTarget = 45f;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private Text text;

    private bool leftAudioOn;
    private bool rightAudioOn;
    public int score = 0;


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

    public void Score(int points)
    {
        score += points;
        text.text = score.ToString();

    }


}
