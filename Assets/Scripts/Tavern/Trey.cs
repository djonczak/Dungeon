using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trey : InteractableItem
{
    [SerializeField] private List<Transform> mugSlot = new List<Transform>();
    private InkeeperInventory keeperInventory;
    public List<Transform> mugs = new List<Transform>();
    public int inTrey = 0;

    [SerializeField] private Transform parent;

    public override void ShowInfo()
    {
        interactText = "Press E/X/A/B to pick up " + itemName;
        HUDEvent.ShowMessage(interactText);
    }

    private void Start()
    {
        parent = transform.parent;
        foreach(Transform child in transform)
        {
            mugSlot.Add(child);
        }
        keeperInventory = PlayerExtension.GetPlayerObject().GetComponent<InkeeperInventory>();
    }

    public void PlaceMug(Transform mug)
    {
        mug.transform.position = new Vector3(mugSlot[inTrey].transform.position.x, mugSlot[inTrey].transform.position.y, mugSlot[inTrey].transform.position.z);
        mug.transform.rotation = mugSlot[inTrey].transform.rotation;
        mug.GetComponent<Rigidbody>().isKinematic = true;
        mug.GetComponent<Collider>().enabled = false;
        mug.transform.parent = mugSlot[inTrey].transform;
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
                guest.TakeOrder(mugs[i].GetComponent<Mug>());
                mugs.Remove(mugs[i]);
                return;
            }
        }
        keeperInventory.canCarry = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        foreach(Transform place in mugSlot)
        {
            Gizmos.DrawWireSphere(place.position, 0.2f);
        }
    }
}
