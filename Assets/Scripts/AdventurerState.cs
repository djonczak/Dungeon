using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurerState : LivingCreature, IDamage
{
    public float currentHP;
    public bool isAttacking;
    public bool isAlive = true;
    private Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        currentHP = amountHP;
    }

    public void TakeDamage(float amount)
    {
        currentHP -= amount;
        Debug.Log("AdventrerHP: " + currentHP);
        if(currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isAlive = false;
        anim.SetTrigger("IsDead");
    }
}
