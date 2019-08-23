using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingQueue : MonoBehaviour
{
   private List<Vector3> positionList;
    private List<Guest> guestList;
   private Vector3 entrancePoint;
    private bool canDraw;

   public void Queue(List<Vector3> positionList)
   {
        this.positionList = positionList;
        entrancePoint = positionList[positionList.Count - 1] + new Vector3(0,0,-20f);
        canDraw = true;
        guestList = new List<Guest>();
   }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if (canDraw == true)
        {
            foreach (Vector3 point in positionList)
            {
                Gizmos.DrawWireSphere(point, 1);
            }
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(entrancePoint, 1);
        }
    }

    public bool CanAddGuest()
    {
        return guestList.Count < positionList.Count;
    }

    public void AddGuest(Guest guest)
    {
        guestList.Add(guest);
        guest.MoveTo(entrancePoint, () => {
            guest.MoveTo(positionList[guestList.IndexOf(guest)],null); 
                });

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
}
