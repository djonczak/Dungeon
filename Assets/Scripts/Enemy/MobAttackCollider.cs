using UnityEngine;

public class MobAttackCollider : MonoBehaviour
{
    [SerializeField] private float _damage;

    private const string Player = "Player";
    private void Start()
    {
        _damage = GetComponentInParent<LivingCreature>().attackDamage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Player))
        {
            other.GetComponent<IDamage>().TakeDamage(_damage, transform.position);
        }
    }
}
