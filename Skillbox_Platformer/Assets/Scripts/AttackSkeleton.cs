using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSkeleton : MonoBehaviour
{
    Skeleton skeleton;
    // Start is called before the first frame update
    void Start()
    {
        skeleton = GetComponentInParent<Skeleton>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInput input = collision.GetComponent<PlayerInput>();
            if (input.isAlive)
            {

                skeleton.playerInCollision = true;
                skeleton.Attack();
                skeleton.player = collision.gameObject;
                skeleton.currentState = Skeleton.State.idle;
            }
        }

        if (collision.CompareTag("EnemyStopper"))
        {
            skeleton.currentState = Skeleton.State.idle;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            skeleton.playerInCollision = false;
        }
    }
}
