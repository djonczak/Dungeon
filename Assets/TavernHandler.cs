using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TavernHandler : MonoBehaviour
{
    public List<Seat> placesToSit;

    public WaitingQueue waitingQueue;

    public float guestAmount;
    public float goldAmount;
    public float servedGuestAmount;
    public float unhandledGuestAmount;

    private void Start()
    {
        waitingQueue.OnGuestArrive += WaitingQueue_OnGuestArrive;
    }

    public void TryToSendGuest()
    {
        Seat emptySeat = GetEmptySeat();
        if(emptySeat != null)
        {
            Guest guest = waitingQueue.GetFirstInQueue();
            if(guest != null)
            {
                guestAmount++;
                emptySeat.SeatGuest(guest);
                guest.MoveTo(emptySeat.seatPosition);
                guest.tavern = this;
                waitingQueue.guestList.Remove(guest);
                // () => { guest.HadBear(); }
            }
        }
    }

    private void WaitingQueue_OnGuestArrive(object sender, System.EventArgs e)
    {
        TryToSendGuest();
        Debug.Log("Jest wolne miejsce");
    }

    public Seat GetEmptySeat()
    {
        foreach(Seat seat in placesToSit)
        {
            if (seat.isEmpty())
            {
                return seat;
            }
        }
        return null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        foreach (Seat point in placesToSit)
        {
            Gizmos.DrawWireSphere(point.seatPosition, 1);
        }
    }
}
