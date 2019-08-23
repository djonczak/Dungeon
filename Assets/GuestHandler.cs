using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestHandler : MonoBehaviour
{
    public Transform firstPosition;
    public WaitingQueue waitingQueue;
    private Guest citizeList;
    public static GuestHandler instance;

    void Start()
    {
        List<Vector3> waitingQuePositionList = new List<Vector3>();
        float positionSize = 5f;
        for(int i = 0; i < 5; i++)
        {
            waitingQuePositionList.Add(firstPosition.transform.position + new Vector3(0, 0, 1) * positionSize * i);
        }
        waitingQueue.Queue(waitingQuePositionList); 
    }

    public void SearchForGuest()
    {
        if (waitingQueue.CanAddGuest())
        {
         //   waitingQueue.AddGuest();
        }
    }
    
}
