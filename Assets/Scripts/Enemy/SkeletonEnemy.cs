using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class SkeletonEnemy : LivingCreature, IDamage
{
    private Animator anim;
    private NavMeshAgent skeleton;
    private float attackCooldown = 0;
    private float currentHP;
    private bool isAlive = true;
    private Transform target;
    private bool canAttack = true;
    private Rigidbody body;

    public float eyesRange;
    public float movementSpeed;
    public float attackSpeed;

    private Color normal;
    private Color damageColor = Color.red;
    private Renderer meshRenderer;
    private bool isDamaged = false;
    private bool canColor;
    float t = 0f;
    public Image HPBar;
    public GameObject HPDisplay;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        skeleton = GetComponent<NavMeshAgent>();
        body = GetComponent<Rigidbody>();
        meshRenderer = GetComponentInChildren<Renderer>();
        normal = meshRenderer.material.color;

        currentHP = amountHP;
        skeleton.speed = movementSpeed;
        anim.SetBool("IsIdle", true);
    }

    void LateUpdate()
    {
        HPDisplay.transform.rotation = Quaternion.identity;
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
                if (canAttack == true)
                {
                    skeleton.SetDestination(target.position);
                }
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
            t += Time.deltaTime / 0.5f;
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

    public void TakeDamage(float amount, Vector3 position)
    {
        if (isDamaged == false)
        {
            currentHP -= amount;
            HPBar.fillAmount = currentHP / amountHP;
            if (currentHP <= 0)
            {
                Die();
            }
            StartCoroutine("Damaged");
            KnockBack(position);
        }
    }

    void Die()
    {
        StopCoroutine("Attack");
        isAlive = false;
        GetComponent<Collider>().enabled = false;
        skeleton.isStopped = true;
        anim.SetTrigger("IsDead");
        HPDisplay.SetActive(false);
        this.enabled = false;
    }

    private void KnockBack(Vector3 position)
    {
        var direction = (transform.position - position).normalized;

        body.AddForce(body.velocity + direction * 20f, ForceMode.Impulse);
    }

    private IEnumerator Damaged()
    {
        canColor = true;
        isDamaged = true;
        yield return new WaitForSeconds(0.5f);
        isDamaged = false;
        t = 0f;
        canColor = false;
    }

    private IEnumerator Attack()
    {
        canAttack = false;

        anim.SetTrigger("IsAttack");
        if(isAlive == false)
        {
            StopCoroutine("Attack");
        }
        yield return new WaitForSeconds(0.8f);
        canAttack = true;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, eyesRange);
        Gizmos.color = Color.red;
    }
}
