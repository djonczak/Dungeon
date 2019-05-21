using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDoll : LivingCreature ,IDamage
{
    private float currentHP;
    private float attackCooldown = 0;
    public float attackSpeed;

    void Start()
    {
        currentHP = amountHP;
    }

    void Update()
    {
        DoAttack();
    }

    private void DoAttack()
    {
        attackCooldown -= Time.deltaTime;
        var sphere = Physics.OverlapSphere(transform.position, 4f, LayerMask.GetMask("Player"));
        if (sphere.Length > 0)
        {
            if (attackCooldown <= 0)
            {

                Debug.Log("Atakuje mnie");
                foreach (var player in sphere)
                {
                    if (player.GetComponent<AdventurerState>().isAlive == true)
                    {
                        player.GetComponent<IDamage>().TakeDamage(1f,transform.position);
                    }
                }
                attackCooldown = 1f / attackSpeed;
            }
        }
    }

    public void TakeDamage(float amount, Vector3 position)
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
