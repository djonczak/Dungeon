using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMelee : MonoBehaviour
{
    private AdventurerState state;
    public float damage;

    private void Start()
    {
        state = GetComponentInParent<AdventurerState>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            damage = state.attackDamage;
            other.GetComponent<IDamage>().TakeDamage(damage, transform.parent.position);
            var meter = GetComponentInParent<AdventurerCombat>();
            if(meter != null)
            {
               meter.FuryMeter();
            }
        }
    }
}

