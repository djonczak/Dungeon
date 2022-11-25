using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tavern.Interactor;

namespace Tavern.Interactable 
{
    public class Trey : InteractableItem
    {
        [SerializeField] private List<Transform> _mugSlot = new List<Transform>();
        private InkeeperInventory _keeperInventory;
        private List<Transform> _mugs = new List<Transform>();
        private int _inTrey = 0;

        [SerializeField] private Transform _parent;
        private string _interactText;

        private void Awake()
        {
            SetTexts();
        }

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            _parent = transform.parent;
            foreach (Transform child in transform)
            {
                _mugSlot.Add(child);
            }
            _keeperInventory = PlayerExtension.GetPlayerObject().GetComponent<InkeeperInventory>();
        }

        public override void SetTexts()
        {
            if (GameManager.Language.Polish == GameManager.Instance.ReturnLanguage())
            {
                _interactText = LanguageText.Polish;
            }
            else
            {
                _interactText = LanguageText.English;
            }
        }

        public override void ShowInfo()
        {
            GameUI.HUDEvent.ShowMessage(_interactText);
        }

        public void PlaceMug(Transform mug)
        {
            mug.transform.position = new Vector3(_mugSlot[_inTrey].transform.position.x, _mugSlot[_inTrey].transform.position.y, _mugSlot[_inTrey].transform.position.z);
            mug.transform.rotation = _mugSlot[_inTrey].transform.rotation;
            mug.GetComponent<Rigidbody>().isKinematic = true;
            mug.GetComponent<Collider>().enabled = false;
            mug.transform.parent = _mugSlot[_inTrey].transform;
            _mugs.Add(mug);
            _inTrey++;
        }

        private void DropMugs()
        {
            foreach (Transform mug in _mugs)
            {
                mug.GetComponent<Collider>().enabled = true;
                mug.GetComponent<Rigidbody>().isKinematic = false;
                mug.parent = _parent;
            }
            _inTrey = 0;
            _mugs.Clear();
        }

        public void GiveGuest(Guests.Guest guest)
        {
            for (int i = 0; i < _mugs.Count; i++)
            {
                if (_mugs[i].GetComponent<Mug>().isFull == true)
                {
                    _inTrey--;
                    _mugs[i].parent = null;
                    guest.TakeOrder(_mugs[i].GetComponent<Mug>());
                    _mugs.Remove(_mugs[i]);
                    return;
                }
            }
            _keeperInventory.SetIfCanCarry(true);
        }

        public int ReturnMugsCount()
        {
            return _mugs.Count;
        }

        public int ReturnMugs()
        {
            return _inTrey;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.layer == 13)
            {
                DropMugs();
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            foreach (Transform place in _mugSlot)
            {
                Gizmos.DrawWireSphere(place.position, 0.2f);
            }
        }
    }
}
