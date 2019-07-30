using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OgreMelee : MonoBehaviour
{
    private OgreEnemy ogreStats;
    private float damage;

    void Start()
    {
        ogreStats = GetComponentInParent<OgreEnemy>();
        damage = ogreStats.attackDamage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<IDamage>().TakeDamage(damage, transform.position);
        }
    }
}
