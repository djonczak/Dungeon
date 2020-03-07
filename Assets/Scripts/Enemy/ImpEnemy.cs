using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class ImpEnemy : LivingCreature, IDamage
{
    [SerializeField] private float _timeToExplode = 8f;

    private Animator _anim;
    private bool _isTicking = false;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    private void Start()
    {
        currentHP = maxHP;
        GetComponent<Explosion>().SetExplosionDamage(attackDamage);
    }

    private void Update()
    {
        if (_anim.GetBool("IsFollow") == true)
        {
            if (_isTicking == false)
            {
                StartCoroutine("ExplosionTimer", _timeToExplode);
                GetComponent<MaterialEffects>().FlickEffect();
                _isTicking = true;
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
        _anim.SetTrigger("IsDead");
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
