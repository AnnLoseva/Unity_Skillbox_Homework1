using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Doors : MonoBehaviour
{
    [SerializeField] private GameObject enter;
    [SerializeField] private GameObject exit;
    [SerializeField] private GameObject enterCollision;
    [SerializeField] private GameObject exitCollision;

    public void Enter()
    {
        enter.SetActive(true);
        exit.SetActive(false);
        enterCollision.SetActive(false);
        exitCollision.SetActive(true);
        Debug.Log("Enter");
    }

    public void Exit()
    {
        exit.SetActive(true);
        enter.SetActive(false);
        exitCollision.SetActive(false);
        enterCollision.SetActive(true);
        Debug.Log("Exit");

    }
}
