using UnityEngine;

namespace Tavern.Player {

    public class InkeeperAnimations : MonoBehaviour
    {
        private Animator _anim;
        private Interactor.InkeeperInventory _inventory;

        private const string IsWalkingTrey = "IsWalkingTrey";
        private const string IsWalking = "IsWalking";
        private const string IsIdle = "IsIdle";
        private const string IsIdleTrey = "IsIdle";

        private void Awake()
        {
            _anim = GetComponent<Animator>();
            _inventory = GetComponent<Interactor.InkeeperInventory>();
        }

        private void Update()
        {
            if (GetComponent<IPlayer>().ReturnMovePosition().magnitude > 0.25f)
            {
                if (_inventory.CheckTrey() == true || _inventory.ReturnMugCount() != 0)
                {
                    _anim.SetBool(IsWalkingTrey, true);
                    _anim.SetBool(IsWalking, false);
                }
                else
                {
                    _anim.SetBool(IsWalking, true);
                    _anim.SetBool(IsWalkingTrey, false);
                }
                _anim.SetBool(IsIdle, false);
                _anim.SetBool(IsIdleTrey, false);
            }
            else
            {
                if (_inventory.CheckTrey() == true || _inventory.ReturnMugCount() != 0)
                {
                    _anim.SetBool(IsIdleTrey, true);
                    _anim.SetBool(IsIdle, false);
                }
                else
                {
                    _anim.SetBool(IsIdle, true);
                    _anim.SetBool(IsIdleTrey, false);
                }
                _anim.SetBool(IsWalking, false);
                _anim.SetBool(IsWalkingTrey, false);
            }
        }
    }
}
