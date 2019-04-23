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
    private bool canAttack = true;

    public float eyesRange;
    public float meleeRange;
    public float movementSpeed;
    public float attackSpeed;
    public Transform meleePoint;

    private Color normal;
    private Color damageColor = Color.red;
    private Renderer meshRenderer;
    private bool isDamaged;
    private bool canColor;
    float t = 0f;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        skeleton = GetComponent<NavMeshAgent>();
        meshRenderer = GetComponentInChildren<Renderer>();
        normal = meshRenderer.material.color;

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

            DamageColor();
        }
    }

    private void DamageColor()
    {
        if (canColor == true)
        {
            t += Time.deltaTime / 1.5f;
            if (isDamaged == true)
            {
                meshRenderer.material.color = Color.Lerp(damageColor, normal, t);
            }
        }
    }

    private void DoAttack()
    {
        attackCooldown -= Time.deltaTime;
        var distance = Vector3.Distance(transform.position, target.position);
        if (distance <= 2.8f)
        {
            anim.SetBool("IsIdle", true);
            anim.SetBool("IsWalk", false);
            skeleton.isStopped = true;
            if (attackCooldown <= 0 && canAttack == true)
            {
                StartCoroutine("Attack");
                attackCooldown = 1f / attackSpeed;
            }
            else
            {
                skeleton.isStopped = false;
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
        StartCoroutine("Damaged");
    }

    void Die()
    {
        isAlive = false;
        GetComponent<Collider>().enabled = false;
        anim.SetTrigger("IsDead");
    }

    private IEnumerator Damaged()
    {
        canColor = true;
        isDamaged = true;
        yield return new WaitForSeconds(1.4f);
        isDamaged = false;
        t = 0f;
        canColor = false;
    }

    private IEnumerator Attack()
    {
        canAttack = false;

        anim.SetTrigger("IsAttack");
        yield return new WaitForSeconds(0.6f);
        var sphere = Physics.OverlapBox(meleePoint.position, new Vector3(meleeRange, meleeRange, meleeRange), Quaternion.identity, LayerMask.GetMask("Player"));
        if (sphere.Length > 0)
        {
            foreach (var player in sphere)
            {
                if (player.GetComponent<AdventurerState>().isAlive == true)
                {
                    player.GetComponent<IDamage>().TakeDamage(attackDamage);
                }
            }
        }
        yield return new WaitForSeconds(0.2f);
        canAttack = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, eyesRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(meleePoint.position, new Vector3(meleeRange, meleeRange, meleeRange));
    }
}
