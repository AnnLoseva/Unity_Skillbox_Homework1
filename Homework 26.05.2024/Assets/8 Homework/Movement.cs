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
    public float speed = 5;

    private Transform target;
    private int npcCounter;
    private int targetCounter;
    private Random random;
    private bool isBackward;
    private bool shouldSwitch;
    private bool canSwitch;


    public int currentMovementType = 1;
    private int nextMovementType = 1;



    private void Start()
    {

        random = new Random();
        npcCounter = 0;
        targetCounter = 1;
        target = points[targetCounter];

        objects[npcCounter].transform.LookAt(target.transform);
    }

    // Update is called once per frame
    void Update()
    {

        objects[npcCounter].transform.position = Vector3.MoveTowards(objects[npcCounter].transform.position, target.position, speed * Time.deltaTime);

        if (objects[npcCounter].transform.position == target.position)
        {
            if (currentMovementType == 1)
            {
                NormalMovement();
            }
            else if(currentMovementType == 2)
            {
                ForwardBackwardMovement();
            }
            else
            {
                RandomMovement();
            }
        }

        if(canSwitch && shouldSwitch)
        {
            currentMovementType = nextMovementType;
            shouldSwitch = false;
        }


    }

    private void NormalMovement()
    {

        if (targetCounter < points.Length - 1)
        {
            npcCounter++;
            targetCounter++;
            canSwitch = false;
        }
        else 
        {
            canSwitch = true;
            Replace();
            npcCounter = 0;
            targetCounter = 0;

        }

        target = points[targetCounter];
        objects[npcCounter].transform.LookAt(target.transform);


    }

    private void ForwardBackwardMovement()
    {
        canSwitch = false;

        if (!isBackward)
        {
            if (targetCounter < points.Length)
            {
                npcCounter++;
                targetCounter++;
            }
            else
            {
                canSwitch = true;
                isBackward = true;
                targetCounter--;
            }
        }
        else
        {
            if (targetCounter > 0)
            {
                npcCounter--;
                targetCounter--;
            }
            else
            {
                canSwitch = true;
                isBackward = false;

                npcCounter = 0;
                targetCounter = 1;
            }
        }

        target = points[targetCounter];
        objects[npcCounter].transform.LookAt(target.transform);
    }

    private void RandomMovement()
    {
        GameObject tempObject = objects[npcCounter];
        objects[npcCounter] = objects[targetCounter];
        objects[targetCounter] = tempObject;
        int rnd = random.Next(0, points.Length);
        targetCounter = rnd;
        target = points[targetCounter];
        objects[npcCounter].transform.LookAt(target.transform);

    }

    private void Replace()
    {
        GameObject lastObject = objects[objects.Length-1];

        for (int i = objects.Length - 1; i > 0 ; i--)
        {
            objects[i] = objects[i - 1];
        }

        objects[0] = lastObject;
    }

    public void NormalMovementButton()
    {
        nextMovementType = 1;

        shouldSwitch = true;
    }

    public void ForwardBackwardMovementButton()
    {
        nextMovementType = 2;

        shouldSwitch = true;
    }

    public void RandomMovementButton()
    {
        nextMovementType = 3;

        shouldSwitch = true;
    }
}


