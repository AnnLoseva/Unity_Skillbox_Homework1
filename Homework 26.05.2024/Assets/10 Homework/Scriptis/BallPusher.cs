using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPusher : MonoBehaviour
{
    [SerializeField] private Transform[] targetPoints;
    [SerializeField] private float pushSpeed = 5f;
    [SerializeField] private float prepareSpeed = 5f;
    [SerializeField] private float power = 50f;
    [SerializeField] private Rigidbody rb;


    private bool animationPlaying;
    private Transform currentPosition;
    private int pointCounter;
    private Vector3[] ballpoints;





    // Start is called before the first frame update
    void Start()
    {
        currentPosition = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (animationPlaying)
        {
            PusherAnimation();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        animationPlaying = true;

    }


    private void PusherAnimation()
    {
        if (pointCounter != 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPoints[pointCounter].position, pushSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPoints[pointCounter].position, prepareSpeed * Time.deltaTime);
        }

        if (transform.position == targetPoints[pointCounter].position)
        {
            if (pointCounter < targetPoints.Length - 1)
            {
                pointCounter++;
            }
            else
            {
                rb.AddForce(transform.forward * power);
                pointCounter = 0;
                animationPlaying = false;
            }
        }

    }

}
