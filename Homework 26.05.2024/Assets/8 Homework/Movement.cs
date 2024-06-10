using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

public class Movement : MonoBehaviour
{

    public float speed = 5;
    public Transform[] points;
    public bool isRandom;

    private Transform target;
    private int i;
    private Random random;
    

    private void Start()
    {
        random = new Random();
        i = 1;
        target = points[i];

        transform.LookAt(target.position);
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            if(isRandom)
            {
                RandomMovement();
            }
            else
            {
                NormalMovement();
            }
        }


    }

    private void NormalMovement()
    {
        
            if (i < points.Length - 1)
            {
                i++;
            }
            else if (i >= points.Length - 1)
            {
                i = 0;
            }

            target = points[i];
            transform.LookAt(target.transform);
        

    }

    private void RandomMovement()
    {
        
            i = random.Next(0, points.Length);
            target = points[i];
            transform.LookAt(target.transform);
        
    }
}

