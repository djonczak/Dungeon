using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMelee : MonoBehaviour
{
    private AdventurerState state;

    public Collider coll;
    
    private void Start()
    {
        coll = GetComponent<Collider>();
        coll.enabled = false;
        state = GetComponent<AdventurerState>();
    }

    private void OnTriggerEnter(Collider other)
    {     
        Debug.Log(other);
        //other.GetComponentInChildren<IDamage>().TakeDamage(state.attackDamage, transform.position);
    }
}
