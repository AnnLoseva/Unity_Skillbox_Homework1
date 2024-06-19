using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DoorsController : MonoBehaviour
{
    [SerializeField] private GameObject enterDoor;
    [SerializeField] private GameObject exitDoor;
    [SerializeField] private GameObject enterDoorCollision;
    [SerializeField] private GameObject exitDoorCollision;

    public void EnterDoor()
    {
        enterDoor.SetActive(true);
        exitDoor.SetActive(false);
        enterDoorCollision.SetActive(false);
        exitDoorCollision.SetActive(true);
    }

    public void ExitDoor()
    {
        exitDoor.SetActive(true);
        enterDoor.SetActive(false);
        exitDoorCollision.SetActive(false);
        enterDoorCollision.SetActive(true);

    }
}
