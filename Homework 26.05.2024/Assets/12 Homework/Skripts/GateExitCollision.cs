using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateExitCollision : MonoBehaviour
{
    [SerializeField] private GateController controller;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ball")
        {
            controller.Close();
        }


    }
}
