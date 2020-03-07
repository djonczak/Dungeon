using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkeeperPickObject : MonoBehaviour
{
    [SerializeField] private Transform _itemToPick;
    private InkeeperInventory _inventory;

    private void Awake()
    {
        _inventory = GetComponent<InkeeperInventory>();
    }

    public void PickItem()
    {
        if (_itemToPick != null)
        {
            _inventory.PickItem(_itemToPick);
            _itemToPick = null;
            HUDEvent.CloseMessage();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mug"))
        {
            if (_itemToPick == null && _inventory.ReturnIfCanCarry())
            {
                _itemToPick = other.transform;
                other.GetComponent<InteractableItem>().ShowInfo();
            }
        }

        if (other.CompareTag("Trey"))
        {
            if (_itemToPick == null)
            {
                _itemToPick = other.transform;
                other.GetComponent<InteractableItem>().ShowInfo();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_itemToPick != null && _itemToPick.name == other.name)
        {
            _itemToPick = null;
            HUDEvent.CloseMessage();
        }
    }

}
