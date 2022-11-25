using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Combat.Enemy 
{
    public class ImpEnemy : LivingCreature, IDamage
    {
        [SerializeField] private float _timeToExplode = 8f;

        private Animator _anim;
        private bool _isTicking = false;

        private const string Follow = "IsFollow";
        private const string Dead = "IsDead";

        private Coroutine _explosionCourotine;

        private void Awake()
        {
            _anim = GetComponent<Animator>();
        }

        private void Start()
        {
            currentHP = maxHP;
            GetComponent<Effects.Explosion>().SetExplosionDamage(attackDamage);
        }

        private void Update()
        {
            if (_anim.GetBool(Follow) == true)
            {
                if (_isTicking == false)
                {
                    _explosionCourotine = StartCoroutine(ExplosionTimer(_timeToExplode));
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
                    Death();
                }
            }
        }

        private void Death()
        {
            isAlive = false;
            _anim.SetTrigger(Dead);
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<NavMeshAgent>().isStopped = true;
            GetComponent<NavMeshAgent>().enabled = false;
            StopCoroutine(_explosionCourotine);
        }

        private IEnumerator ExplosionTimer(float time)
        {
            yield return new WaitForSeconds(time);
            GetComponent<Effects.Explosion>().Explode();
        }
    }
}
