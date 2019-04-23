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

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        state = GetComponent<AdventurerState>();
       // meleeWeapon = GetComponentInChildren<ActivateMelee>();
    }

    private void Update()
    {
        attackCooldown -= Time.deltaTime;
    }

    public void LightAttack()
    {
        if (attackCooldown <= 0)
        {
            StartCoroutine("Attack");
            attackCooldown = 1f / attackSpeed;
        }
    }

    IEnumerator Attack()
    {
        state.isAttacking = true;
        anim.SetTrigger("IsAttack");
        // meleeWeapon.coll.enabled = true;
        yield return new WaitForSeconds(1f);
        var attack = Physics.OverlapBox(attackPoint.position, new Vector3(attackRange, attackRange, attackRange), Quaternion.identity , LayerMask.GetMask("Enemy"));
        foreach(var enemy in attack)
        {
            enemy.GetComponent<IDamage>().TakeDamage(1f);
        }
        yield return new WaitForSeconds(1f);
        state.isAttacking = false;
       // meleeWeapon.coll.enabled = false;
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(attackPoint.position, new Vector3(attackRange, attackRange, attackRange));
    }

}
