using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

public class Movement : MonoBehaviour
{
    public GameObject[] objects;
    public Transform[] points;
    public bool isRandom;
    public float speed = 5;

    private Transform target;
    private int i;
    private Random random;
     
    

    private void Start()
    {

        random = new Random();
        i = 0;
        target = points[i+1];

        transform.LookAt(target.transform);

    }

    // Update is called once per frame
    void Update()
    {

        objects[i].transform.position = Vector3.MoveTowards(objects[i].transform.position, target.position, speed * Time.deltaTime);

        if (objects[i].transform.position == target.position)
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
            target = points[i + 1];
        }
            else if (i>= points.Length - 1)
            {
                i = 0;
            target = points[i+1];
        }
            transform.LookAt(target.transform);
        

    }

    private void RandomMovement()
    {
            
            i = random.Next(0, points.Length);
            target = points[i];
            transform.LookAt(target.transform);
        
    }
}

