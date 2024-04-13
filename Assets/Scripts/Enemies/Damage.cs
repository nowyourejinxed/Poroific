using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private Stats stats;
    private EnemyAI enemyAI;
    private int attackDamage;
    private float attackRange = 1.0f;
    private bool isAttacking = false;
    private float lastAttackTime;
    public float attackCooldown = 1.0f;
    

    private void Start()
    {
        stats = GetComponent<Stats>();
        enemyAI = GetComponent<EnemyAI>();
        attackDamage = stats.damage;
        attackRange = enemyAI.stopDistance + 0.5f;
    }

    private void Update()
    {
        if (isAttacking)
        {
            if (Time.time - lastAttackTime >= attackCooldown)
            {
                isAttacking = false;
            }
        }

        if (CanAttack())
        {
            Attack();
        }
    }

    private bool CanAttack()
    {
        if (!isAttacking && enemyAI.currentTarget != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, enemyAI.currentTarget.position);
            return distanceToTarget <= attackRange;
        }

        return false;
    }

    private void Attack()
    {
        lastAttackTime = Time.time;
        isAttacking = true;
        HitTarget();
    }


    private void HitTarget()
    {
        HealthUI playerStats = enemyAI.currentTarget.gameObject.GetComponent<HealthUI>();
        playerStats?.TakeDamage(stats.damage);
        //Destroy(gameObject);
    }

}
