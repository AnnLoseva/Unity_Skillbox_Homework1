using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroGravitySphere : MonoBehaviour
{

    [SerializeField] private Transform[] transforms;
    [SerializeField] private float speed = 5;
    private int targetCounter;


    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transforms[targetCounter].position, speed * Time.deltaTime);

        if(transform.position == transforms[targetCounter].position)
        {
            if (targetCounter < transforms.Length-1) 
            {
                targetCounter++;
            }
            else
            {
                targetCounter = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        rb.useGravity = true;
    }

}
