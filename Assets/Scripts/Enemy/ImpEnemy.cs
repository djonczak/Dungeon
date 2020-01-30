using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ImpEnemy : LivingCreature, IDamage
{
    [SerializeField] private float timeToExplode = 8f;

    private Animator anim;
    private bool isTicking = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        currentHP = maxHP;
        GetComponent<Explosion>().SetExplosionDamage(attackDamage);
    }

    private void Update()
    {
        if (anim.GetBool("IsFollow") == true)
        {
            if (isTicking == false)
            {
                StartCoroutine("ExplosionTimer", timeToExplode);
                GetComponent<MaterialEffects>().FlickEffect();
                isTicking = true;
            }
        }
    }

    public void TakeDamage(float amount, Vector3 position)
    {
        if (isAlive)
        {
            currentHP -= amount;
            GetComponent<KnockBack>().KnockBackEffect(position);
            if (currentHP <= 0)
            {
                Dead();
            }
        }
    }

    private void Dead()
    {
        isAlive = false;
        anim.SetTrigger("IsDead");
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<NavMeshAgent>().isStopped = true;
        GetComponent<NavMeshAgent>().enabled = false;
        StopAllCoroutines();
    }

    private IEnumerator ExplosionTimer(float time)
    {
        yield return new WaitForSeconds(time);
        GetComponent<Explosion>().Explode();
    } 
}
