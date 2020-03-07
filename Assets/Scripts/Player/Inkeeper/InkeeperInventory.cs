using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkeeperInventory : MonoBehaviour
{
    [SerializeField] private bool _isUsingTray;
    [SerializeField] Transform _treyPosition;
    [SerializeField] private GameObject _trey;
    public Transform[] handsPoint;
    [SerializeField] private List<Transform> _mugs = new List<Transform>();
    [SerializeField] private  int _inHand = -1;
    private bool _canCarry = true;

    private void Start()
    {
        _treyPosition = TransformExtension.GetChildObject(this.transform, "TreyPosition");
    }
    
    public void PickItem(Transform item)
    {
        if (item.CompareTag("Mug"))
        {
            if (_canCarry == true)
            {
                TakeMug(item);
            }
        }

        if (item.CompareTag("Trey"))
        {
            if (item.GetComponent<Trey>().ReturnMugs() == 4 && _inHand > -1)
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
        if (_isUsingTray)
        {
            DropDownTrey();
        }
        else
        {
            if (_mugs.Count != 0)
            {
                DropMug();
            }
        }
    }

    private void PickTrey(Transform item)
    {
        _trey = item.gameObject;
        _trey.transform.parent = transform;
        _trey.transform.position = _treyPosition.position;
        _trey.transform.rotation = _treyPosition.rotation;
        _trey.GetComponent<Rigidbody>().isKinematic = true;
        _trey.GetComponent<Collider>().enabled = false;
        _isUsingTray = true;
        _canCarry = true;

        if (_mugs.Count != 0)
        {
            for (int j = 0; j < _mugs.Count; j++)
            {
                if (_trey.GetComponent<Trey>().ReturnMugs() < 4)
                {
                    _trey.GetComponent<Trey>().PlaceMug(_mugs[j]);
                    _inHand--;
                }
                else
                {
                    DropMug();
                }
            }
            _mugs.Clear();
        }
    }

    private void DropDownTrey()
    {
        if (_trey != null)
        {
            _trey.transform.parent = null;
            _trey.GetComponent<Rigidbody>().isKinematic = false;
            _trey.GetComponent<Collider>().enabled = true;
            _trey = null;
            _isUsingTray = false;
            _canCarry = true;
        }
    }

    private void TakeMug(Transform mug)
    {
        if (_isUsingTray == true)
        {
            PutMugOnTrey(mug);
        }
        else
        {
            if (_inHand <= 1)
            {
                _mugs.Add(mug);
                _inHand++;
                PutMugInHand(mug);
            }
        }
    }

    private void PutMugOnTrey(Transform mug)
    {
        if (_trey.GetComponent<Trey>().ReturnMugs() < 4)
        {
            _trey.GetComponent<Trey>().PlaceMug(mug);
        }
        if (_trey.GetComponent<Trey>().ReturnMugs() == 4)
        {
            _canCarry = false;
        }
    }

    private void PutMugInHand(Transform mug)
    {
        if (_inHand == 0)
        {
            mug.transform.parent = handsPoint[0].transform;
            mug.transform.position = new Vector3(handsPoint[0].position.x, handsPoint[0].position.y, handsPoint[0].position.z);
            mug.transform.rotation = handsPoint[0].rotation;
            mug.GetComponent<Collider>().enabled = false;
            mug.GetComponent<Rigidbody>().isKinematic = true;
        }
        if (_inHand == 1)
        {
            mug.transform.parent = handsPoint[1].transform;
            mug.transform.position = new Vector3(handsPoint[1].position.x, handsPoint[1].position.y, handsPoint[1].position.z);
            mug.transform.rotation = handsPoint[1].rotation;
            mug.GetComponent<Collider>().enabled = false;
            mug.GetComponent<Rigidbody>().isKinematic = true;
            _canCarry = false;
        }
    }

    private void DropMug()
    {
        var mug = _mugs[_mugs.Count - 1];
        mug.parent = null;
        mug.GetComponent<Rigidbody>().isKinematic = false;
        mug.GetComponent<Collider>().enabled = true;
        _inHand--;
        _mugs.Remove(mug);
        _canCarry = true;
    }

    public void GiveGuest(Guest guest)
    {
        for (int i = 0; i < _mugs.Count; i++)
        {
            if (_mugs[i].GetComponent<Mug>().isFull == true)
            {
                _inHand--;
                _mugs[i].parent = null;
                guest.TakeOrder(_mugs[i].GetComponent<Mug>());
                _mugs.Remove(_mugs[i]);
                return;
            }
        }
    }
    
    public bool CheckTrey()
    {
        return _isUsingTray;
    }

    public bool ReturnIfCanCarry()
    {
        return _canCarry;
    }

    public int ReturnMugCount()
    {
        return _mugs.Count;
    }

    public Trey ReturnTrey()
    {
        return _trey.GetComponent<Trey>();
    }

    public void SetIfCanCarry(bool state)
    {
        _canCarry = state;
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
