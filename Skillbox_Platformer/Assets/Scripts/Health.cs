using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;
    [SerializeField] private bool isPlayer = false;
    [SerializeField] private GameObject deathScreen;

    private Animator animator;
    private PlayerInput input;
    private Skeleton skeleton;
    private Rigidbody2D rb;
    private Collider2D collider2d;
    

    private void Start()
    {
        animator = GetComponent<Animator>();
        input = GetComponent<PlayerInput>();
        skeleton = GetComponent<Skeleton>();
        rb = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<Collider2D>();

        if (isPlayer)
        {
            for (int i = 0; i < hearts.Length; i++)
            {
                if (i < health)
                {
                    hearts[i].sprite = fullHeart;
                }
                else
                {
                    hearts[i].sprite = emptyHeart;
                }

                if (i < numOfHearts)
                {
                    hearts[i].enabled = true;
                }
                else
                {
                    hearts[i].enabled = false;
                }
            }
        }
    }

    public void BackToIdle()
    {
        animator.SetTrigger("Idle");
    }

    public void ChangeHPPlayher(int damage)
    {
        health -= damage;


        if (input.isAlive)
        {

            if (health <= 0)
            {
                animator.SetTrigger("Death");
                rb.gravityScale = 0;
                collider2d.isTrigger = true;
                input.isAlive = false;

                StartCoroutine(ShowDeathScreenWithDelay(1f));

            }
            else
            {
                if (damage > 0)
                {
                    animator.SetTrigger("Hit");
                }
            }
        }
            if (health > numOfHearts)
            {
                numOfHearts = health;
            }
            for (int i = 0; i < hearts.Length; i++)
            {
                if (i < health)
                {
                    hearts[i].sprite = fullHeart;
                }
                else
                {
                    hearts[i].sprite = emptyHeart;
                }

                if (i < numOfHearts)
                {
                    hearts[i].enabled = true;
                }
                else
                {
                    hearts[i].enabled = false;
                }
            }

        }

    public void ChangeHPEnemy(int damage)
    {
        health -= damage;


        if (skeleton.isAlive)
        {

            if (health <= 0)
            {
                animator.SetTrigger("Death");
                rb.gravityScale = 0;
                collider2d.isTrigger = true;
                skeleton.isAlive = false;



            }
            else
            {
                if (damage > 0)
                {
                    animator.SetTrigger("Hit");
                }
            }
        }
    }

    private IEnumerator ShowDeathScreenWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Задержка на заданное количество секунд

        deathScreen.SetActive(true); // Активируем экран смерти
    }
}
