using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMelee : MonoBehaviour
{
    private AdventurerState state;
    public float damage;
    private SoundManager sound;

    private void Start()
    {
        state = GetComponentInParent<AdventurerState>();
        sound = GetComponentInParent<SoundManager>();
        damage = state.attackDamage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            sound.AttackSound();
            damage = state.attackDamage;
            other.GetComponent<IDamage>().TakeDamage(damage, transform.parent.position);
            var meter = GetComponentInParent<AdventurerCombat>();
            if(meter != null)
            {
           //    meter.FuryMeter();
            }
        }
    }
}

