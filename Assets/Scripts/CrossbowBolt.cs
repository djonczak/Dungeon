using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossbowBolt : MonoBehaviour
{
    public float damage;
    private GameObject poolerParent;
    private AudioSource sound;

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
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            other.GetComponent<IDamage>().TakeDamage(damage, transform.position);
            if (other.tag != "Imp")
            {
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                transform.parent = other.transform;
                GetComponent<Rigidbody>().isKinematic = true;
                GetComponent<BoxCollider>().enabled = false;
            }
        }
        else
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<BoxCollider>().isTrigger = false;
            GetComponent<Rigidbody>().useGravity = true;
        }
        sound.PlayOneShot(sound.clip, 0.1f);
        Invoke("DisableObject", 13f);
        gameObject.layer = 12;
    }

    public void DisableObject()
    {
        transform.parent = poolerParent.transform;
        this.gameObject.SetActive(false);
    }
}
