using UnityEngine;

public class MobAttackCollider : MonoBehaviour
{
    [SerializeField] private float damage;

    private void Start()
    {
        damage = GetComponentInParent<LivingCreature>().attackDamage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<IDamage>().TakeDamage(damage, transform.position);
        }
    }
}
