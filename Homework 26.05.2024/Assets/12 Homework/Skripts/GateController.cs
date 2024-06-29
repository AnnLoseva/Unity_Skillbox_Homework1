using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WildBall.Inputs;

public class GateController : MonoBehaviour
{
    [SerializeField] private GameObject text;
    private Animator animator;
    private bool interactibleControl;

    private void Update()
    {
        if(interactibleControl)
        {
            Open();
        }
    }

    void Start()
    {
        animator = GetComponent<Animator>();

    }

    public void Open()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("Open");
        }
    }

    public void Close()
    {
        animator.SetTrigger("Close");
    }

    public void IsInteractible(bool interactible)
    {
        animator.SetBool("Interactible", interactible);
        interactibleControl = interactible; 

        if(interactibleControl) 
        {
            text.SetActive(true);
        }
        else 
        {
            text.SetActive(false);
        }
    }

    public void Finish()
    {
        animator.SetTrigger("Finish");
    }


}
