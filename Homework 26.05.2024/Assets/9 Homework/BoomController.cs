using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BoomController : MonoBehaviour
{
    public float radius = 5f;
    public float explosionPower = 1f;

    private float distanceToEpicenter;
    private Vector3 forceOnCube;
    private Vector3 direction;

    private List<Rigidbody> cubes = new List<Rigidbody> { };

    private void OnTriggerEnter(Collider collider)
    {
        Rigidbody rb = collider.gameObject.GetComponent<Rigidbody>();
        cubes.Add(rb);
        Debug.Log(cubes[0].name);
        
    }

    private void OnTriggerExit(Collider collider)
    {
        Rigidbody rb = collider.gameObject.GetComponent<Rigidbody>();
        cubes.Remove(rb);
    }

    public void Boom()
    {
        foreach(Rigidbody i in cubes)
        {
            distanceToEpicenter = Vector3.Distance(transform.position, i.transform.position);
           direction = i.transform.position - transform.forward;
           forceOnCube = (radius - distanceToEpicenter) * explosionPower * direction.normalized;

            i.AddForce(forceOnCube);
        }
    }
}
