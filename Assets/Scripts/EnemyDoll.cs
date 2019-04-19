using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDoll : LivingCreature ,IDamage
{
    private float currentHP;

    void Start()
    {
        currentHP = amountHP;
    }

    public void TakeDamage(float amount)
    {
        currentHP -= amount;
        Debug.Log(currentHP);
        if(currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        gameObject.SetActive(false);
        Debug.Log(creatureName + "is dead.");
    }

}
