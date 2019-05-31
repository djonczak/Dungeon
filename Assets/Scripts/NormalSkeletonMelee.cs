using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSkeletonMelee : MonoBehaviour
{
    private SkeletonEnemy skeleton;
    private float damage;

    void Start()
    {
        skeleton = GetComponentInParent<SkeletonEnemy>();
        damage = skeleton.attackDamage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<IDamage>().TakeDamage(damage, transform.position);
        }
    }
}
