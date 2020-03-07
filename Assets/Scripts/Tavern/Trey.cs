using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trey : InteractableItem
{
    [SerializeField] private List<Transform> _mugSlot = new List<Transform>();
    private InkeeperInventory _keeperInventory;
    private List<Transform> _mugs = new List<Transform>();
    private int _inTrey = 0;

    [SerializeField] private Transform _parent;

    public override void ShowInfo()
    {
        interactText = "Press E/X/A/B to pick up " + itemName;
        HUDEvent.ShowMessage(interactText);
    }

    private void Start()
    {
        _parent = transform.parent;
        foreach(Transform child in transform)
        {
            _mugSlot.Add(child);
        }
        _keeperInventory = PlayerExtension.GetPlayerObject().GetComponent<InkeeperInventory>();
    }

    public void PlaceMug(Transform mug)
    {
        mug.transform.position = new Vector3(_mugSlot[_inTrey].transform.position.x, _mugSlot[_inTrey].transform.position.y, _mugSlot[_inTrey].transform.position.z);
        mug.transform.rotation = _mugSlot[_inTrey].transform.rotation;
        mug.GetComponent<Rigidbody>().isKinematic = true;
        mug.GetComponent<Collider>().enabled = false;
        mug.transform.parent = _mugSlot[_inTrey].transform;
        _mugs.Add(mug);
        _inTrey++;
    }

    void DropMugs()
    {
        foreach (Transform mug in _mugs)
        {
            mug.GetComponent<Collider>().enabled = true;
            mug.GetComponent<Rigidbody>().isKinematic = false;
            mug.parent = _parent;
        }
        _inTrey = 0;
        _mugs.Clear();
    }

    public void GiveGuest(Guest guest)
    {
        for (int i = 0; i < _mugs.Count; i++)
        {
            if(_mugs[i].GetComponent<Mug>().isFull == true)
            {
                _inTrey--;
                _mugs[i].parent = null;
                guest.TakeOrder(_mugs[i].GetComponent<Mug>());
                _mugs.Remove(_mugs[i]);
                return;
            }
        }
        _keeperInventory.SetIfCanCarry(true);
    }

    public int ReturnMugsCount()
    {
        return _mugs.Count;
    }

    public int ReturnMugs()
    {
        return _inTrey;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 13)
        {
            DropMugs();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        foreach(Transform place in _mugSlot)
        {
            Gizmos.DrawWireSphere(place.position, 0.2f);
        }
    }
}
