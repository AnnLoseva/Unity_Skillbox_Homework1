using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WildBall.Inputs
{
    [RequireComponent(typeof(PlayerMovement))]

    public class PlayerInput : MonoBehaviour
    {
        private Vector3 movement;
        private Vector3 jump;
        private PlayerMovement playerMovement;

        private void Awake()
        {
            playerMovement = GetComponent<PlayerMovement>();
            jump = new Vector3(0, 1, 0).normalized;
        }

        void Update()
        {
            float horizontal = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
            float vertical = Input.GetAxis(GlobalStringVars.VERTICAL_AXIS);

            movement = new Vector3(horizontal, 0, vertical).normalized;

            if (Input.GetButtonDown(GlobalStringVars.JUMP_BUTTON))
            {
                Debug.Log("jump");
                playerMovement.JumpCharacter(jump);
            }

        }

        private void FixedUpdate()
        {
            playerMovement.MoveCharacter(movement);

           
        }
    }
}
