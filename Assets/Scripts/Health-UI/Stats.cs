using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [Header("Base Stats")]
    public float currentHealth;
    public float targetHealth;
    public int damage;

    public void TakeDamage(GameObject target, float damageAmount)
    {
        Stats targetStats = target.GetComponent<Stats>();
        targetStats.targetHealth -= damageAmount;
        if(target.CompareTag("Enemy") && targetStats.targetHealth <= 0)
        {
            Destroy(target.gameObject);
            //increment UI counter?
        }
    }

}
