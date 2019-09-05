using System;
using System.Collections.Generic;
using UnityEngine;

public class WaitingQueue : MonoBehaviour
{
    public event EventHandler OnGuestArrive;
    public event EventHandler CloseTavern;

    //private List<Vector3> positionList;
    public List<Guest> guestList;
    //private Vector3 entrancePoint;
    //private bool canDraw;

    public void Queue()
    {
        //this.positionList = positionList;
        //entrancePoint = positionList[positionList.Count - 1] + new Vector3(0,0,-20f);
        //canDraw = true;
        guestList = new List<Guest>();
    }

    //public bool CanAddGuest()
    //{
    //    return guestList.Count < positionList.Count;
    //}

    public void AddGuest(Guest guest)
    {
        guestList.Add(guest);
        //guest.MoveTo(positionList[guestList.IndexOf(guest)]);
        if(OnGuestArrive != null)
        {
            OnGuestArrive(this, EventArgs.Empty);
        }
    }

    public Guest GetFirstInQueue()
    {
        if(guestList.Count == 0)
        {
            return null;
        }
        else
        {
            Guest guest = guestList[0];
            guestList.RemoveAt(0);
            return guest;
        }
    }

    public void CloseInn()
    {
        if (CloseTavern != null)
        {
            CloseTavern(this, EventArgs.Empty);
        }
    }

    //public void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.green;
    //    if (canDraw == true)
    //    {
    //        foreach (Vector3 point in positionList)
    //        {
    //            Gizmos.DrawWireSphere(point, 1);
    //        }
    //        Gizmos.color = Color.cyan;
    //        Gizmos.DrawWireSphere(entrancePoint, 1);
    //    }
    //}
}
