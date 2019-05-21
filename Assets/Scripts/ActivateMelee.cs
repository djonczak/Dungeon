using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMelee : MonoBehaviour
{
    public float damage;

    public Collider coll;

    private void Start()
    {
        coll = GetComponent<Collider>();
        coll.enabled = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Debug.Log(other.name + " " + "dealt " + "damage.");
            //other.GetComponent<IDamage>().TakeDamage(damage);
        }
    }
}
