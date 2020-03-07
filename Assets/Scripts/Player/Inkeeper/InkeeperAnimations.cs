using UnityEngine;

public class InkeeperAnimations : MonoBehaviour
{
    private Animator _anim;
    private InkeeperInventory _inventory;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _inventory = GetComponent<InkeeperInventory>();
    }

    private void Update()
    {
        if (GetComponent<IPlayer>().ReturnMovePosition().magnitude > 0.25f)
        {
            if (_inventory.CheckTrey() == true || _inventory.ReturnMugCount() != 0)
            {
                _anim.SetBool("IsWalkingTrey", true);
                _anim.SetBool("IsWalking", false);
            }
            else
            {
               _anim.SetBool("IsWalking", true);
                _anim.SetBool("IsWalkingTrey", false);
            }
            _anim.SetBool("IsIdle", false);
            _anim.SetBool("IsIdleTrey", false);
        }
        else
        {
            if (_inventory.CheckTrey() == true || _inventory.ReturnMugCount() != 0)
            {
                _anim.SetBool("IsIdleTrey", true);
                _anim.SetBool("IsIdle", false);
            }
            else
            {
                _anim.SetBool("IsIdle", true);
                _anim.SetBool("IsIdleTrey", false);
            }
            _anim.SetBool("IsWalking", false);
            _anim.SetBool("IsWalkingTrey", false);
        }
    }
}
