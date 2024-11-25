using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private AttackPlayer playerAttack;
    public bool isAlive = true;
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerAttack = GetComponentInChildren<AttackPlayer>();
    }


    void Update()
    {
        if (isAlive)
        {
            float horizontalDirection = Input.GetAxis(GlobalStringVar.HORIZONTAL_AXIS);
            bool isJumpButtonPressed = Input.GetButtonDown(GlobalStringVar.JUMP);
            bool isAttackButtonPressed = Input.GetButtonDown(GlobalStringVar.ATTACK);

            playerMovement.Move(horizontalDirection, isJumpButtonPressed);
            playerAttack.Attack(isAttackButtonPressed);

            playerMovement.AnimationStates();
        }
    }
}
