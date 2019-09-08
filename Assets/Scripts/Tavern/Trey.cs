using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trey : InteractableItem
{
    public Transform[] mugPlace;
    public InkeeperInventory inventory;
    public List<Transform> mugs = new List<Transform>();
    public int inTrey = 0;
    [SerializeField] private Transform parent;

    public override void ShowInfo()
    {
        interactText = "Press E/X/A/B to pick up " + itemName;
    }

    private void Start()
    {
        parent = transform.parent;
    }

    public void PlaceMug(Transform mug)
    {
        mug.transform.position = new Vector3(mugPlace[inTrey].transform.position.x, mugPlace[inTrey].transform.position.y, mugPlace[inTrey].transform.position.z);
        mug.transform.rotation = mugPlace[inTrey].transform.rotation;
        mug.GetComponent<Rigidbody>().isKinematic = true;
        mug.GetComponent<Collider>().enabled = false;
        mug.transform.parent = mugPlace[inTrey].transform;
        mugs.Add(mug);
        inTrey++;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 13)
        {
            DropMugs();
        }
    }

    void DropMugs()
    {
        foreach (Transform mug in mugs)
        {
            mug.GetComponent<Collider>().enabled = true;
            mug.GetComponent<Rigidbody>().isKinematic = false;
            mug.parent = parent;
        }
        inTrey = 0;
        mugs.Clear();
    }

    public void GiveGuest(Guest guest)
    {
        for (int i = 0; i < mugs.Count; i++)
        {
            if(mugs[i].GetComponent<Mug>().isFull == true)
            {
                inTrey--;
                mugs[i].parent = null;
                guest.TakeBear(mugs[i].GetComponent<Mug>());
                mugs.Remove(mugs[i]);
                return;
            }
        }
        inventory.canCarry = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        foreach(Transform place in mugPlace)
        {
            Gizmos.DrawWireSphere(place.position, 0.2f);
        }
    }
}
