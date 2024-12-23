using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WildBall.Inputs
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField, Range(0,10)] private float speed = 2.0f;
        [SerializeField, Range(0,20)] private float jumpHeight = 10.0f;

        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        public void MoveCharacter(Vector3 movement)
        {
            rb.AddForce(movement * speed);
        }

        public void JumpCharacter(Vector3 jump)
        {
            rb.AddForce(jump * jumpHeight, ForceMode.Impulse);
        }

#if UNITY_EDITOR
        [ContextMenu("Reset values")]
        public void ResetValues()
        {
            speed = 2;
            jumpHeight = 5;
        }
#endif
    }
}

