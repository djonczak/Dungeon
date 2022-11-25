using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tavern.Guests 
{
    public class GuestHandler : MonoBehaviour
    {
        public Transform exitPoint;
        public WaitingQueue waitingQueue;
        public List<Guest> citizenList = new List<Guest>();
        public static GuestHandler instance = null;

        [SerializeField] private bool isOpened;
        [SerializeField] private float tavernWorkTime = 1000;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            //List<Vector3> waitingQuePositionList = new List<Vector3>();
            //float positionSize = 5f;
            //for(int i = 0; i < 5; i++)
            //{
            //    waitingQuePositionList.Add(firstPosition.transform.position + new Vector3(0, 0, 1) * positionSize * i);
            //}
            // waitingQueue.Queue();
        }

        public void OpenTavern()
        {
            isOpened = true;
            InvokeRepeating("AddGuest", 2f, 5f);
            Invoke("CloseTaver", tavernWorkTime);
        }

        public void CloseTaver()
        {
            CancelInvoke("AddGuest");
            Debug.Log("Zamknięte");
            waitingQueue.CloseInn();
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
}
