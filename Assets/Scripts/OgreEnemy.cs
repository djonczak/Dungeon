using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class OgreEnemy : LivingCreature, IDamage
{
    enum HPState
    {
        Full,
        Half,
    };

    private Animator anim;
    private NavMeshAgent ogr;
    private float attackCooldown = 0;
    private float currentHP;
    private bool isAlive = true;
    private Transform target;
    private HPState phase;
    private string runAnimation = "IsRun";
    private bool doneRoar;
    private bool canAttack = true;

    public float eyesRange;
    public float meleeRange;
    public float walkSpeed;
    public float runSpeed;
    public float attackSpeed;
    public Transform meleePoint;
    public float secondPhaseAttackSpeed;
    public Image HPBar;
    public GameObject HPDisplay;

    //Changing color on damage
    private Color normal;
    private Color damageColor = Color.red;
    public Renderer meshRenderer;
    private bool isDamaged;
    private bool canColor;
    float t = 0f;
    private int lastAttack;
    private int randomAttack;
    private bool isInvincible;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        ogr = GetComponent<NavMeshAgent>();
        normal = meshRenderer.material.color;

        currentHP = amountHP;
        ogr.speed = walkSpeed;
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
                if (target.GetComponent<AdventurerState>().isAlive == true)
                {
                    ogr.SetDestination(target.position);
                    anim.SetBool("IsIdle", false);
                    if (phase == HPState.Full)
                    {
                        anim.SetBool("IsWalk", true);
                    }
                    else
                    {
                        anim.SetBool(runAnimation, true);
                    }

                    DoAttack();
                }
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
        if (distance <= 4.5f)
        {
            anim.SetBool("IsIdle", true);
            anim.SetBool("IsWalk", false);
            anim.SetBool(runAnimation, false);
            ogr.isStopped = true;
            if (attackCooldown <= 0 && canAttack == true)
            {
                StartCoroutine("Attack");
                attackCooldown = 1f / attackSpeed;
            }
            else
            {
                ogr.isStopped = false;
            }
        }
 
    }

    public void TakeDamage(float amount, Vector3 position)
    {
        if (isInvincible == false)
        {
            currentHP -= amount;
            HPBar.fillAmount = currentHP / amountHP;
            if (currentHP <= 0)
            {
                Die();
            }
            CheckHPState();
            StartCoroutine("Damaged");
        }
    }

    private void Die()
    {
        StopCoroutine("Attack");
        isAlive = false;
        GetComponent<Collider>().enabled = false;
        meshRenderer.material.color = normal;
        anim.SetTrigger("IsDead");
        HPDisplay.SetActive(false);
        this.enabled = false;
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

    private IEnumerator Roar()
    {
        isInvincible = true;
        anim.SetTrigger("IsSecondPhase");
        canAttack = false;
        ogr.speed = 0f;
        yield return new WaitForSeconds(5f);
        isInvincible = false;
        ogr.speed = runSpeed;
        attackSpeed = secondPhaseAttackSpeed;
        canAttack = true;
        doneRoar = true;
    }

    private IEnumerator Attack()
    {
        Debug.Log("Atakuje");
        canAttack = false;
        while (lastAttack == randomAttack)
        {
            randomAttack = Random.Range(1, 4);
        }
        lastAttack = randomAttack;
        Debug.Log(randomAttack);
        if (randomAttack == 1)
        {
            anim.SetTrigger("SwingAttack");
        }
        if (randomAttack == 2)
        {
            anim.SetTrigger("Punch1");
        }
        if (randomAttack == 3)
        {
            anim.SetTrigger("Punch2");
        }
        if (isAlive == false)
        {
            StopCoroutine("Attack");
        }
        yield return new WaitForSeconds(0.7f);
        var sphere = Physics.OverlapBox(meleePoint.position, new Vector3(meleeRange, meleeRange, meleeRange), Quaternion.identity, LayerMask.GetMask("Player"));
        if (sphere.Length > 0)
        {
            foreach (var player in sphere)
            {
                if (player.GetComponent<AdventurerState>().isAlive == true)
                {
                    player.GetComponent<IDamage>().TakeDamage(attackDamage, new Vector3(0f,0f,0f));
                }
            }
        }
        yield return new WaitForSeconds(0.2f);
        canAttack = true;
    }

    private void CheckHPState()
    {
        var hpPercent = (100f /amountHP) * currentHP;
        if(hpPercent > 51)
        {
            phase = HPState.Full;
        }
        else
        {
            phase = HPState.Half;
            if(doneRoar == false)
            {
                StartCoroutine("Roar");
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, eyesRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(meleePoint.position, new Vector3(meleeRange, meleeRange, meleeRange));
    }
}
