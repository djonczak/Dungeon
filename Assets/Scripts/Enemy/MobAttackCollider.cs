using UnityEngine;

public class MobAttackCollider : MonoBehaviour, IPassFloat
{
    [SerializeField] private float damage;

    public void PassFloat(float amount)
    {
        damage = amount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<IDamage>().TakeDamage(damage, transform.position);
        }
    }
}
