using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Superman : MonoBehaviour
{
    public float power;
    public float powerModificator = 1000;
    public Slider slider;
    public Transform[] objects;

    private Vector3[] objectPositions;

    private Vector3 direction;

    private List<Rigidbody> badGuys = new List<Rigidbody> { };

    private void Start()
    {
        objectPositions = new Vector3[objects.Length];

        for(int i = 0; i<objects.Length; i++)
        {
            objectPositions[i] = objects[i].position;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {

        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

        badGuys.Add(rb);

        direction = rb.transform.position - transform.position;

        rb.AddForce(direction.normalized * power);
    }

    private void OnCollisionExit(Collision collision)
    {
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

        badGuys.Remove(rb);
    }

    public void ChangePower()
    {
        power = powerModificator * slider.value;
    }

    public void Hit()
    {
        foreach (var bg in badGuys)
        {
            

            direction = bg.transform.position - transform.position;

            bg.AddForce(direction.normalized * power);
        }
    }

    public void Reset()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].position = objectPositions[i];

            Rigidbody rb = objects[i].GetComponent<Rigidbody>();
            rb.velocity = new Vector3(0, 0, 0);
        }
    }


}

