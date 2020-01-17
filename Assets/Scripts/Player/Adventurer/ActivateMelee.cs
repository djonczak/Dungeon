using UnityEngine;

public class ActivateMelee : MonoBehaviour,IPassFloat
{
    [SerializeField] private float damage;

    public void PassFloat(float amount)
    {
        damage = amount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            GetComponentInParent<ISoundEffects>().AttackSound();
            other.GetComponent<IDamage>().TakeDamage(damage, transform.parent.position);
           // var meter = GetComponentInParent<AdventurerCombat>();
           // if(meter != null)
           // {
           ////    meter.FuryMeter();
           // }
        }
    }
}

