using UnityEngine;
using UnityEngine.AI;
using Tavern.Interactor;

namespace Tavern.Guests 
{
    public class Guest : MonoBehaviour
    {
        private NavMeshAgent _agent;
        [SerializeField] private int goldAmount = 5;
        public Seat seat;
        public Transform handPosition;

        private TavernHandler _tavern;
        private Transform _mug;
        private bool _canOrder;
        public SphereCollider coll;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            GuestHandler.instance.citizenList.Add(this);
            coll.enabled = false;
        }

        public void MoveTo(Vector3 position)
        {
            _agent.SetDestination(position);
        }

        // TODO: Orders drink and wait for it, if didn't get then go out of tavern

        public void Order()
        {
            Debug.Log("Może zamówić");
            coll.enabled = true;
            Invoke("Unhandled", 30f);
            _canOrder = true;
        }

        // TODO: Takes drink and starts to gossips

        public void TakeOrder(Interactable.Mug mug)
        {
            _mug = mug.transform;
            mug.transform.position = new Vector3(handPosition.position.x, handPosition.position.y, handPosition.position.z);
            mug.transform.rotation = handPosition.rotation;
            CancelInvoke("Unhandled");
            coll.enabled = false;
            Invoke("Served", 30f);
        }

        // TODO: Drink bear/wine then pay and exit from tavern

        private void Served()
        {
            LeaveMug();
            _tavern.goldAmount += goldAmount;
            _tavern.servedGuestAmount++;
            ExitTavern();
        }

        private void LeaveMug()
        {
            _mug.parent = null;
            _mug.GetComponent<Collider>().enabled = true;
            _mug.GetComponent<Rigidbody>().isKinematic = false;
            _mug.GetComponent<Interactable.Mug>().DirtyMug();
            _mug = null;
        }

        // TODO: Waiting for drink, if didn't get then go out of tavern

        public void Unhandled()
        {
            _tavern.unhandledGuestAmount++;
            _canOrder = false;
            ExitTavern();
        }

        // TODO: Exit tavern and go towards exit point then cleans variables for next time

        private void ExitTavern()
        {
            Debug.Log("Wychodzi");
            //  _tavern.TryToSendGuest();
            seat.EmptySeat();
            seat = null;
            _tavern = null;
            MoveTo(GuestHandler.instance.exitPoint.position);
        }

        // TODO: Checking if had collided with player, then take a drink

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && _mug == null && _canOrder == true)
            {
                InkeeperInventory inventory = other.GetComponent<InkeeperInventory>();
                if (inventory != null)
                {
                    if (inventory.CheckTrey())
                    {
                        var trey = inventory.ReturnTrey();
                        if (trey != null)
                        {
                            if (trey.ReturnMugsCount() != 0)
                            {
                                trey.GiveGuest(this);
                            }
                        }
                    }
                    else
                    {
                        if (inventory.ReturnMugCount() != 0)
                        {
                            inventory.GiveGuest(this);
                        }
                    }
                }
            }
        }

        public void SetTavern(TavernHandler tavernHandler)
        {
            _tavern = tavernHandler;
        }

        // TODO: Draw gizmo sphere for hand position

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(handPosition.position, 0.3f);
        }
    }
}
