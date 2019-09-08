using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkeeperInventory : MonoBehaviour
{
    public bool isUsingTray;
    public Transform trayPosition;
    public GameObject trey;
    public Transform[] handsPoint;
    public List<Transform> mugs = new List<Transform>();
    [SerializeField] int inHand = -1;
    public bool canCarry = true;

    public void PickItem(Transform item)
    {
        if (item.tag == "Mug")
        {
            if (canCarry == true)
            {
                TakeMug(item);
            }
        }

        if (item.tag == "Trey")
        {
            if (item.GetComponent<Trey>().inTrey == 4 && inHand > -1)
            {

            }
            else
            {
                PickTrey(item);
            }
        }
    }

    public void DropItem()
    {
        if (isUsingTray)
        {
            DropDownTrey();
        }
        else
        {
            if (mugs.Count != 0)
            {
                DropMug();
            }
        }
    }

    private void PickTrey(Transform item)
    {
        trey = item.gameObject;
        trey.transform.parent = transform;
        trey.transform.position = trayPosition.position;
        trey.transform.rotation = trayPosition.rotation;
        trey.GetComponent<Rigidbody>().isKinematic = true;
        trey.GetComponent<Collider>().enabled = false;
        trey.GetComponent<Trey>().inventory = this;
        isUsingTray = true;
        canCarry = true;

        if (mugs.Count != 0)
        {
            for (int j = 0; j < mugs.Count; j++)
            {
                if (trey.GetComponent<Trey>().inTrey < 4)
                {
                    trey.GetComponent<Trey>().PlaceMug(mugs[j]);
                    inHand--;
                }
                else
                {
                    DropMug();
                }
            }
            mugs.Clear();
        }
    }

    private void DropDownTrey()
    {
        if (trey != null)
        {
            trey.transform.parent = null;
            trey.GetComponent<Rigidbody>().isKinematic = false;
            trey.GetComponent<Collider>().enabled = true;
            trey = null;
            isUsingTray = false;
            canCarry = true;
        }
    }

    private void TakeMug(Transform mug)
    {
        if (isUsingTray == true)
        {
            PutMugOnTrey(mug);
        }
        else
        {
            if (inHand <= 1)
            {
                mugs.Add(mug);
                inHand++;
                PutMugInHand(mug);
            }
        }
    }

    private void PutMugOnTrey(Transform mug)
    {
        if (trey.GetComponent<Trey>().inTrey < 4)
        {
            trey.GetComponent<Trey>().PlaceMug(mug);
        }
        if (trey.GetComponent<Trey>().inTrey == 4)
        {
            canCarry = false;
        }
    }

    private void PutMugInHand(Transform mug)
    {
        if (inHand == 0)
        {
            mug.transform.parent = handsPoint[0].transform;
            mug.transform.position = new Vector3(handsPoint[0].position.x, handsPoint[0].position.y, handsPoint[0].position.z);
            mug.transform.rotation = handsPoint[0].rotation;
            mug.GetComponent<Collider>().enabled = false;
            mug.GetComponent<Rigidbody>().isKinematic = true;
        }
        if (inHand == 1)
        {
            mug.transform.parent = handsPoint[1].transform;
            mug.transform.position = new Vector3(handsPoint[1].position.x, handsPoint[1].position.y, handsPoint[1].position.z);
            mug.transform.rotation = handsPoint[1].rotation;
            mug.GetComponent<Collider>().enabled = false;
            mug.GetComponent<Rigidbody>().isKinematic = true;
            canCarry = false;
        }
    }

    private void DropMug()
    {
        var mug = mugs[mugs.Count - 1];
        mug.parent = null;
        mug.GetComponent<Rigidbody>().isKinematic = false;
        mug.GetComponent<Collider>().enabled = true;
        inHand--;
        mugs.Remove(mug);
        canCarry = true;
    }

    public void GiveGuest(Guest guest)
    {
        for (int i = 0; i < mugs.Count; i++)
        {
            if (mugs[i].GetComponent<Mug>().isFull == true)
            {
                inHand--;
                mugs[i].parent = null;
                guest.TakeBear(mugs[i].GetComponent<Mug>());
                mugs.Remove(mugs[i]);
                return;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        foreach (Transform place in handsPoint)
        {
            Gizmos.DrawWireSphere(place.position, 0.2f);
        }
    }
}
