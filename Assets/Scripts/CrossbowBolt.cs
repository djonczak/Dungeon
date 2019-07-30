using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossbowBolt : MonoBehaviour
{
    public float damage;
    private GameObject poolerParent;

    private void OnEnable()
    {
        gameObject.layer = 0;
        GetComponent<BoxCollider>().isTrigger = true;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<BoxCollider>().enabled = true;
    }

    private void Start()
    {
        poolerParent = this.transform.parent.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<IDamage>().TakeDamage(damage, transform.position);
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.parent = other.transform;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<BoxCollider>().isTrigger = false;
            GetComponent<Rigidbody>().useGravity = true;
        }
        Invoke("DisableObject", 15f);
        gameObject.layer = 12;
    }

    void DisableObject()
    {
        transform.parent = poolerParent.transform;
        this.gameObject.SetActive(false);
    }
}
