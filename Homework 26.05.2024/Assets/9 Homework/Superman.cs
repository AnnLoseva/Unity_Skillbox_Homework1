using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Superman : MonoBehaviour
{
    public float power;
    public float powerModificator = 1000;
    public Slider slider;

    private Vector3 direction;

    private List<Rigidbody> badGuys = new List<Rigidbody> { };

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);

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


}

