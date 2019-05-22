using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMelee : MonoBehaviour
{
    private AdventurerState state;
    private float damage;

    private void Start()
    {
        state = GetComponentInParent<AdventurerState>();
        damage = state.attackDamage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<IDamage>().TakeDamage(damage, transform.position);
        }
    }
}

