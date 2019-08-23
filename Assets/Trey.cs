﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trey : InteractableItem
{
    public Transform[] mugPlace;
    public InkeeperInventory inventory;
    public List<Transform> mugs = new List<Transform>();
    public int inTrey = 0;

    public override void OnInteract()
    {
        itemName = "Trey";
        interactText = "Press E/X/A/B to pick up " + itemName;
        //  base.OnInteract();
    }

    public void PlaceMug(Transform mug)
    {
        mug.transform.position = new Vector3(mugPlace[inTrey].transform.position.x,0, mugPlace[inTrey].transform.position.z);
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
            mug.parent = null;
        }
        inTrey = 0;
        mugs.Clear();
    }
}
