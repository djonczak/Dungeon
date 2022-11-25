using System.Collections;
using UnityEngine;

namespace Combat.Effects 
{
    public class Explosion : MonoBehaviour
    {
        [SerializeField] private float _explosionDamage = 0f;
        [SerializeField] private float _explosionRange = 5f;
        [SerializeField] private LayerMask _damagableObjects = 11;

        private ParticleSystem _explosionEffect;

        private void Awake()
        {
            _explosionEffect = GetComponentInChildren<ParticleSystem>();
        }

        public void Explode()
        {
            StartCoroutine(ExplosionEffectDuration(_explosionEffect.main.duration));
        }

        private IEnumerator ExplosionEffectDuration(float time)
        {
            GetComponentInChildren<Renderer>().enabled = false;
            _explosionEffect.Play();
            var damagable = Physics.OverlapSphere(transform.position, _explosionRange, _damagableObjects);
            if (damagable.Length > 0)
            {
                damagable[0].GetComponent<IDamage>().TakeDamage(_explosionDamage, transform.position);
            }
            yield return new WaitForSeconds(time);
            gameObject.SetActive(false);
        }

        public void SetExplosionDamage(float amount)
        {
            _explosionDamage = amount;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _explosionRange);
        }
    }
}
