using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    private Health enemyHealth;
    private Animator animator;
    private bool isAttackButtonPressedDuringAnimation;
    private bool canAttack = true;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInParent<Animator>();

    }

    private float attackTimer = 0f;

    private void Update()
    {
        if(!canAttack && !isAttackButtonPressedDuringAnimation)
        {
            attackTimer += Time.deltaTime;

            if (attackTimer > 1.5f)
            {
                canAttack = true;
            }
        }
        else
        {
            attackTimer = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemyHealth = collision.GetComponent<Health>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemyHealth = null; 
        }
    }

    public void Attack(bool isAttackButtonPressed)
    {
        if (isAttackButtonPressed)
        {
            isAttackButtonPressedDuringAnimation = true;

            if (canAttack)
            {
                AnimationAttack(1); // ��������� ������ �����
                canAttack = false; // ��������� ���������� ����� �� ��������� �������
            }
        }
    }

    public void AnimationAttack(int attackNum)
    {
        if (isAttackButtonPressedDuringAnimation)
        {
            animator.SetInteger("Attack", attackNum); // ��������� ��������� �����, ���� ������ ���� ������
            isAttackButtonPressedDuringAnimation = false; // ���������� ����
        }
        else
        {
            animator.SetInteger("Attack", 0); // ���������� �������� ����� � �������� ���������
            canAttack = true; // ��������� ��������� �����
        }
    }

    public void DealDamageToEnemy(int damage)
    {
        if (enemyHealth != null)
        {
            enemyHealth.ChangeHPEnemy(damage);

        }
    }




}
