using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitCollider : MonoBehaviour
{
    [SerializeField] private Doors doors;
    [SerializeField] private GameObject ball;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == ball)
        {
            doors.Exit();
        }
    }
}
