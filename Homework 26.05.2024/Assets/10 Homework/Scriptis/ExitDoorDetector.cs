using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoorDetector : MonoBehaviour
{
    [SerializeField] private DoorsController doorsController;
    [SerializeField] private GameObject exitBall;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == exitBall)
        {
            doorsController.ExitDoor();
        }
    }
}
