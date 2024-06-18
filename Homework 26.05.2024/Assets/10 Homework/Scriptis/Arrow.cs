using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float power;
    [SerializeField] private AudioClip clip;
    [SerializeField] private AudioSource source;

    private void Start()
    {
        source.clip = clip;
    }
    private void OnTriggerEnter(Collider collision)
    {

        rb.AddForce(transform.forward * power);
        source.Play();
    }

}
