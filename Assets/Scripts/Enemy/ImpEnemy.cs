using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ImpEnemy : MonoBehaviour, IDamage
{
    public float movementSpeed;
    public float eyesRange;
    public float explosionTimer;
    public float explosionRange;
    public float explosionDamage;

    private NavMeshAgent imp;
    private ParticleSystem explosion;
    private Renderer bodyColor;
    private Animator anim;
    private Transform target;
    private bool isExplosion = false;
    private Color normalColor = new Color(0f, 0f, 0f, 0f);
    private bool isTicking = false;


    void Start()
    {
        imp = GetComponent<NavMeshAgent>();
        explosion = GetComponentInChildren<ParticleSystem>();
        bodyColor = GetComponentInChildren<Renderer>();
        anim = GetComponentInChildren<Animator>();
        imp.speed = movementSpeed;
    }

    void Update()
    {
        if(isExplosion == false)
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
                    imp.SetDestination(target.position);
                    anim.SetTrigger("IsRun");
                    ColorFlick();
                    if(isTicking == false)
                    {
                        StartCoroutine("ExplosionTimer", explosionTimer);
                        isTicking = true;
                    }
                }
            }

        }
    }

    void ColorFlick()
    {
        var indicatorColor = Color.Lerp(Color.white, normalColor, Mathf.PingPong(Time.time, 1));
        bodyColor.material.SetColor("_EmissionColor", indicatorColor);
    }

    public void TakeDamage(float amount, Vector3 direction)
    {
        KnockBack(direction);
    }

    public void KnockBack(Vector3 position)
    {
        var direction = (transform.position - position).normalized;

        GetComponent<Rigidbody>().AddForce(direction * 650f);
       // imp.speed = 0f;
    }

    private IEnumerator ExplosionTimer(float time)
    {
        yield return new WaitForSeconds(time);
        imp.speed = 0f;
        GetComponentInChildren<Renderer>().enabled = false;
        explosion.Play();
        var damagable = Physics.OverlapSphere(transform.position, explosionRange, LayerMask.GetMask("Player"));
        if (damagable.Length > 0)
        {
            damagable[0].GetComponent<IDamage>().TakeDamage(explosionDamage, transform.position);
        }
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    } 

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, eyesRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRange);
    }
}
