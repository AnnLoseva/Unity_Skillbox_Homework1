using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnterDoorDetector : MonoBehaviour
{
    [SerializeField] private DoorsController doorsController;

    [SerializeField] private Collider ball;

    private void OnTriggerEnter(Collider other)
    {
        if (other == ball)
        {
            doorsController.EnterDoor();
        }
    }
}
