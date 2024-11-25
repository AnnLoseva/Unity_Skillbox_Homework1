using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float waitTime = 2f;


    private Animator animator;
    public GameObject player;
    public bool playerInCollision;
    public enum State {idle, walk, revert};
    public State currentState;
    private float currentTimeToRevert = 0;
    private Rigidbody2D rb;
    public bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        WalkState();
    }

    public void BackToIdle()
    {
        animator.SetTrigger("Idle");
    }

   

    public void Attack()
    {
        if (isAlive) 
        { 
            if (playerInCollision)
            {
                animator.SetTrigger("Attack");
            }
            else
            {
                animator.SetTrigger("Idle");
            }
        }
    }

    private void MakeDamage()
    {
        if (playerInCollision)
        {
            Health playerHealth = player.GetComponent<Health>();
            playerHealth.ChangeHPPlayher(damage);
        }
    }


    private void WalkState()
    {
        if (isAlive)
        {
            if (currentTimeToRevert >= waitTime)
            {
                currentTimeToRevert = 0;
                currentState = State.revert;
            }


            switch (currentState)
            {
                case State.idle:
                    animator.SetBool("Walk", false);
                    currentTimeToRevert += Time.deltaTime;
                    break;

                case State.walk:
                    animator.SetBool("Walk", true);
                    rb.velocity = Vector2.right * speed;
                    break;

                case State.revert:
                    speed *= -1;
                    currentState = State.walk;

                    if (transform.localScale.x == 1)
                    {
                        transform.localScale = new Vector3(-1, 1, 1);
                    }
                    else
                    {
                        transform.localScale = new Vector3(1, 1, 1);
                    }
                    break;



            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
                    
    }

}
