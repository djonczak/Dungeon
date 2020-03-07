using UnityEngine;

public class AdventurerAnimation : MonoBehaviour
{
    private AdventurerState _state;
    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _state = GetComponent<AdventurerState>();
    }

    private void Update()
    {
        MoveAnimation(GetComponent<IPlayer>().ReturnMovePosition());
        WeaponAimingAnimation(GetComponent<IPlayer>().ReturnRotationPosition());
    }

    private void MoveAnimation(Vector2 playerPosition)
    {
        if (_state.ReturnAimingState() == false)
        {
            if (playerPosition.magnitude > 0.25f)
            {
                _anim.SetFloat("VelNormal", Mathf.Abs(playerPosition.magnitude));
            }
            else
            {
                _anim.SetFloat("VelNormal", Mathf.Abs(playerPosition.magnitude));
            }
        }
    }

    private void WeaponAimingAnimation(Vector2 playerPosition)
    {
        if (_state.ReturnAimingState() == true)
        {
            _anim.SetFloat("VelXCombat", playerPosition.x);
            _anim.SetFloat("VelYCombat", playerPosition.y);
            if (_state.ReturnWeponState() == true)
            {
                _anim.SetBool("IsSword", true);
                _anim.SetBool("IsCrosbow", false);
            }
            else
            {
                _anim.SetBool("IsSword", false);
                _anim.SetBool("IsCrosbow", true);
            }
        }
        else
        {
            _anim.SetBool("IsSword", false);
            _anim.SetBool("IsCrosbow", false);
        }
    }
    
    public void MeleeAttackAnimation(int animationNumber)
    {
        _anim.SetTrigger("Melee" + animationNumber);
    }
}
