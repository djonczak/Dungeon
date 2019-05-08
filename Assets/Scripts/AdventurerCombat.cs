using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurerCombat : MonoBehaviour
{
    private AdventurerState state;
    private Animator anim;
    private float attackCooldown;
    public float attackSpeed;
    public Transform attackPoint;
    public float attackRange;
    //private ActivateMelee meleeWeapon;
    private int comboMeter = 0;
    private bool nexAttack = true;
    private ParticleSystem weaponTrail;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        state = GetComponent<AdventurerState>();
        weaponTrail = GetComponentInChildren<ParticleSystem>();
       // meleeWeapon = GetComponentInChildren<ActivateMelee>();
    }

    private void Update()
    {
        attackCooldown -= Time.deltaTime;
    }

    public void LightAttack()
    {
        if (attackCooldown <= 0 && nexAttack == true)
        {
            StartCoroutine("Attack");
            attackCooldown = 1f / attackSpeed;
        }
    }

    IEnumerator Attack()
    {
        weaponTrail.Play();
        nexAttack = false;
        StopCoroutine("ComboBreaker");
        state.isAttacking = true;
        comboMeter++;
        anim.SetTrigger("IsAttack" + comboMeter);
        // meleeWeapon.coll.enabled = true;
        yield return new WaitForSeconds(0.3f);
        var attack = Physics.OverlapBox(attackPoint.position, new Vector3(attackRange, attackRange, attackRange), Quaternion.identity , LayerMask.GetMask("Enemy"));
        foreach(var enemy in attack)
        {
            enemy.GetComponent<IDamage>().TakeDamage(3f);
        }
        yield return new WaitForSeconds(1f);
        nexAttack = true;
        StartCoroutine("ComboBreaker");
        if (comboMeter == 3)
        {
            comboMeter = 0;
            StopCoroutine("ComboReaker");
        }
       // meleeWeapon.coll.enabled = false;
    }

    private IEnumerator ComboBreaker()
    {
        anim.SetBool("IsIdle", true);
        anim.SetBool("IsRun", false);
        yield return new WaitForSeconds(0.6f);
        state.isAttacking = false;
        comboMeter = 0;
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(attackPoint.position, new Vector3(attackRange, attackRange, attackRange));
    }

}
