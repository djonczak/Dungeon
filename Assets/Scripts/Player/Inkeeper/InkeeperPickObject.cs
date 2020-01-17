using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkeeperPickObject : MonoBehaviour
{
    [SerializeField] private Transform itemToPick;
    private InkeeperInventory inventory;

    private void Awake()
    {
        inventory = GetComponent<InkeeperInventory>();
    }

    public void PickItem()
    {
        if (itemToPick != null)
        {
            inventory.PickItem(itemToPick);
            itemToPick = null;
            HUDEvent.CloseMessage();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Mug")
        {
            if (itemToPick == null && inventory.canCarry == true)
            {
                itemToPick = other.transform;
                other.GetComponent<InteractableItem>().ShowInfo();
            }
        }

        if (other.tag == "Trey")
        {
            if (itemToPick == null)
            {
                itemToPick = other.transform;
                other.GetComponent<InteractableItem>().ShowInfo();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (itemToPick != null && itemToPick.name == other.name)
        {
            itemToPick = null;
            HUDEvent.CloseMessage();
        }
    }

}
