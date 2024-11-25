using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float jumpForce = 3f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float floorOffsetDistance = 0f;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private AnimationCurve curve;
    
    private Animator animator;
    private Collider2D coll;
    private enum AnimationState { idle, run, jump, fall}; 
    private Rigidbody2D rb;
    private AttackPlayer attackPlayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        attackPlayer = GetComponentInChildren<AttackPlayer>();

    }

    public void Move(float direction, bool isJumpButtonPressed)
    {

        if(Mathf.Abs(direction) > 0.01f)
        {
            HorizontalMovement(direction);
            
        }
        
        if(isJumpButtonPressed) 
        {
            Jump();
        }

    }

    private void Jump()
    {
        if (IsGrounded())
        {
            
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void HorizontalMovement(float direction)
    {
        rb.velocity = new Vector2(curve.Evaluate(direction) * speed, rb.velocity.y);
        if(rb.velocity.x > 0.1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
            
        }
        else if (rb.velocity.x < -0.1f)
        {
            
            transform.localScale = new Vector3(-1, 1, 1);
        }
        
    }

    public void CallDealDamage(int damage)
    {
        attackPlayer.DealDamageToEnemy(damage);
    }

    public void CallAnimationAttack(int attackNum)
    {
        attackPlayer.AnimationAttack(attackNum);
    }


    public void AnimationStates()
    {

        AnimationState state = new AnimationState();

        if(IsGrounded())
        {
            if(Input.GetAxis("Horizontal") > 0.1 || Input.GetAxis("Horizontal") < -0.1f)
            {
                state = AnimationState.run;
            }
            else
            {
                state = AnimationState.idle;
            }
        }
        else
        {
            if(rb.velocity.y < 0.1f)
            {
                state = AnimationState.fall;
            }
            else
            {
                state = AnimationState.jump;
            }
        }

        animator.SetInteger("state", (int)state);   
    }


    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, floorOffsetDistance, groundLayerMask);
    }

}
