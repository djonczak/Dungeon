using System;
using System.Collections.Generic;
using UnityEngine;

public class GuestHandler : MonoBehaviour
{
    public Transform exitPoint;
    public WaitingQueue waitingQueue;
    public List<Guest> citizenList = new List<Guest>();
    public static GuestHandler instance = null;

    public bool isOpened;

    void Awake()
    {
        instance = this;
        //List<Vector3> waitingQuePositionList = new List<Vector3>();
        //float positionSize = 5f;
        //for(int i = 0; i < 5; i++)
        //{
        //    waitingQuePositionList.Add(firstPosition.transform.position + new Vector3(0, 0, 1) * positionSize * i);
        //}
        waitingQueue.Queue();
        waitingQueue.OnGuestArrive += WaitingQueue_OnGuestArrive; 
        InvokeRepeating("AddGuest", 2f, 5f);
        
    }

    private void WaitingQueue_OnGuestArrive(object sender, System.EventArgs e)
    {
        Debug.Log("Dodano gościa");
    }

    public void AddGuest()
    {
        if (citizenList.Count != 0 && isOpened == true) 
        {
            Guest guest = citizenList[citizenList.Count - 1];
            waitingQueue.AddGuest(guest);
            citizenList.Remove(guest);
        }
    }   
}
