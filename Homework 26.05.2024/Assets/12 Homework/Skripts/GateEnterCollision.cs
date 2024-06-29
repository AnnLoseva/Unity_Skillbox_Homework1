using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateEnterCollision : MonoBehaviour
{
    [SerializeField] private GateController controller;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Ball")
        {
            controller.IsInteractible(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Ball")
        {
            controller.IsInteractible(false);
        }
    }
}
