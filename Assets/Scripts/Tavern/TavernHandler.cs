using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tavern {

    public class TavernHandler : MonoBehaviour
    {
        public List<Guests.Seat> placesToSit;

        //private WaitingQueue waitingQueue;

        public float guestAmount;
        public float goldAmount;
        public float servedGuestAmount;
        public float unhandledGuestAmount;

        private void Start()
        {
            // waitingQueue.OnGuestArrive += WaitingQueue_OnGuestArrive;
            // waitingQueue.CloseTavern += WaitingQueue_CloseTavern;
        }

        //public void TryToSendGuest()
        //{
        //    Seat emptySeat = GetEmptySeat();
        //    if(emptySeat != null)
        //    {
        //        Guest guest = waitingQueue.GetFirstInQueue();
        //        if(guest != null)
        //        {
        //            guestAmount++;
        //            emptySeat.SeatGuest(guest);
        //            guest.MoveTo(emptySeat.seatPosition);
        //            guest.SetTavern(this);
        //          //  waitingQueue.guestList.Remove(guest);
        //        }
        //    }
        //}

        private void WaitingQueue_OnGuestArrive(object sender, System.EventArgs e)
        {
            //  TryToSendGuest();
            Debug.Log("Jest wolne miejsce");
        }

        private void WaitingQueue_CloseTavern(object sender, System.EventArgs e)
        {
            Debug.Log("Zamykamy tawerne");
            foreach (Guests.Seat seat in placesToSit)
            {
                seat.Close();
            }

        }

        private Guests.Seat GetEmptySeat()
        {
            foreach (Guests.Seat seat in placesToSit)
            {
                if (seat.IsEmpty())
                {
                    return seat;
                }
            }
            return null;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            foreach (Guests.Seat point in placesToSit)
            {
                Gizmos.DrawWireSphere(point.seatPosition, 1);
            }
        }

        public void OnDestroy()
        {
            // waitingQueue.OnGuestArrive -= WaitingQueue_OnGuestArrive;
            //  waitingQueue.CloseTavern -= WaitingQueue_CloseTavern;
        }
    }
}
