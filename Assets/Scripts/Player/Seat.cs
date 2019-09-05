using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seat : MonoBehaviour
{
    public Guest guest;
    public Vector3 seatPosition;

    private void Start()
    {
        seatPosition = this.transform.position;
    }

    public bool isEmpty()
    {
        return guest == null;
    }

    public void SeatGuest(Guest guest)
    {
        this.guest = guest;
        guest.seat = this;
    }

    public void EmptySeat()
    {
        guest = null;
    }

    public void Close()
    {
        if (guest != null)
        {
            guest.Unhandled();
            guest = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (guest != null)
        {
            if (other.name == guest.name)
            {
                guest.Order();
            }
        }
    }
}
