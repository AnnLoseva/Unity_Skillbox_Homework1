using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportpoint : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private Transform teleportPoint;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == ball)
        {
            ball.transform.position = teleportPoint.position;
            audioSource.Play();
        }
    }
}
