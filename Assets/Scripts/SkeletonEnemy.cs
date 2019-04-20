using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonEnemy : LivingCreature, IDamage
{
    private Animator anim;
    private NavMeshAgent skeleton;
    private float attackCooldown = 0;
    private float currentHP;
    private bool isAlive = true;
    private Transform target;

    public float eyesRange;
    public float meleeRange;
    public float movementSpeed;
    public float attackSpeed;
    public Transform meleePoint;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        skeleton = GetComponent<NavMeshAgent>();

        currentHP = amountHP;
        skeleton.speed = movementSpeed;
        anim.SetBool("IsIdle", true);
    }

    void Update()
    {
        if (isAlive == true)
        {
            if (target == null)
            {
                var sphereVision = Physics.OverlapSphere(transform.position, eyesRange, LayerMask.GetMask("Player"));
                if (sphereVision.Length > 0)
                {
                    target = sphereVision[0].transform;
                }
            }

            if (target != null)
            {
                skeleton.SetDestination(target.position);
                anim.SetBool("IsIdle", false);
                anim.SetBool("IsWalk", true);
                DoAttack();
            }
        }
    }

    private void DoAttack()
    {
        attackCooldown -= Time.deltaTime;
        var sphere = Physics.OverlapBox(meleePoint.position, new Vector3(meleeRange, meleeRange, meleeRange), Quaternion.identity, LayerMask.GetMask("Player"));
        if (sphere.Length > 0)
        {
            if (attackCooldown <= 0)
            {
                anim.SetTrigger("IsAttack");
                Debug.Log("Atakuje mnie");
                foreach (var player in sphere)
                {
                    if (player.GetComponent<AdventurerState>().isAlive == true)
                    {
                        player.GetComponent<IDamage>().TakeDamage(2f);
                    }
                }
                attackCooldown = 1f / attackSpeed;
            }
        }
    }

    public void TakeDamage(float amount)
    {
        currentHP -= amount;
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, eyesRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(meleePoint.position, new Vector3(meleeRange, meleeRange, meleeRange));
    }
}
