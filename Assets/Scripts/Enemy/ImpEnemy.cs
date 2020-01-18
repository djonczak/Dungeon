using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ImpEnemy : LivingCreature, IDamage
{
    public float explosionTimer;
    public float explosionRange;

    private ParticleSystem explosion;
    private Renderer bodyColor;
    private Animator anim;
    private bool isExplosion = false;
    private Color normalColor = new Color(0f, 0f, 0f, 0f);
    private bool isTicking = false;

    private void Start()
    {
        explosion = GetComponentInChildren<ParticleSystem>();
        bodyColor = GetComponentInChildren<Renderer>();
        anim = GetComponentInChildren<Animator>();
        currentHP = maxHP;
    }

    private void Update()
    {
        if (isExplosion == false)
        {
            if (anim.GetBehaviour<AIFollow>().target != null)
            {
                ColorFlick();
                if (isTicking == false)
                {
                    StartCoroutine("ExplosionTimer", explosionTimer);
                    isTicking = true;
                }
            }
        }
    }

    private void ColorFlick()
    {
        var indicatorColor = Color.Lerp(Color.white, normalColor, Mathf.PingPong(Time.time, 1));
        bodyColor.material.SetColor("_EmissionColor", indicatorColor);
    }

    public void TakeDamage(float amount, Vector3 direction)
    {
        currentHP -= amount;
        KnockBack(direction);
        if(currentHP <= 0)
        {
            bodyColor.material.SetColor("_EmissionColor", normalColor);
            isExplosion = true;
            anim.SetTrigger("IsDead");
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<NavMeshAgent>().isStopped = true;
            GetComponent<NavMeshAgent>().enabled = false;
            StopAllCoroutines();
        }
    }


    private void KnockBack(Vector3 position)
    {
        var direction = (transform.position - position).normalized;

        GetComponent<Rigidbody>().AddForce(GetComponent<Rigidbody>().velocity + direction * 22f, ForceMode.Impulse);
    }

    private IEnumerator ExplosionTimer(float time)
    {
        yield return new WaitForSeconds(time);
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponentInChildren<Renderer>().enabled = false;
        explosion.Play();
        var damagable = Physics.OverlapSphere(transform.position, explosionRange, LayerMask.GetMask("Player"));
        if (damagable.Length > 0)
        {
            damagable[0].GetComponent<IDamage>().TakeDamage(attackDamage, transform.position);
        }
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    } 

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRange);
    }
}
