using System.Collections;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float explosionDamage = 0f;
    [SerializeField] private float explosionRange = 5f;
    [SerializeField] private LayerMask damagableObjects = 11;
    private ParticleSystem explosionEffect;

    private void Awake()
    {
        explosionEffect = GetComponentInChildren<ParticleSystem>();
    }

    public void Explode()
    {
        StartCoroutine("ExplosionEffectDuration", explosionEffect.main.duration);
    }

    private IEnumerator ExplosionEffectDuration(float time)
    {
        GetComponentInChildren<Renderer>().enabled = false;
        explosionEffect.Play();
        var damagable = Physics.OverlapSphere(transform.position, explosionRange, damagableObjects);
        if (damagable.Length > 0)
        {
            damagable[0].GetComponent<IDamage>().TakeDamage(explosionDamage, transform.position);
        }
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }

    public void SetExplosionDamage(float amount)
    {
        explosionDamage = amount;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRange);
    }
}
