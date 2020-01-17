using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurerAnimation : MonoBehaviour
{
    private AdventurerState state;
    private AdventurerMovement movement;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        state = GetComponent<AdventurerState>();
        movement = GetComponent<AdventurerMovement>();
    }

    void Update()
    {
        WeaponAimingAnimation();

        if (state.isAiming == false)
        {
            if (movement.movePosition.magnitude > 0.25f)
            {
                anim.SetFloat("VelNormal", Mathf.Abs(movement.movePosition.magnitude));
            }
            else
            {
                anim.SetFloat("VelNormal", Mathf.Abs(movement.movePosition.magnitude));
            }
        }
    }

    private void WeaponAimingAnimation()
    {
        if (state.isAiming)
        {
            anim.SetFloat("VelXCombat", movement.movePosition.x);
            anim.SetFloat("VelYCombat", movement.movePosition.y);
            if (state.isMelee == true)
            {
                anim.SetBool("IsSword", true);
                anim.SetBool("IsCrosbow", false);
            }
            else
            {
                anim.SetBool("IsSword", false);
                anim.SetBool("IsCrosbow", true);
            }
        }
        else
        {
            anim.SetBool("IsSword", false);
            anim.SetBool("IsCrosbow", false);
        }
    }

    public void MeleeAttackAnimation(int animationNumber)
    {
        anim.SetTrigger("Melee" + animationNumber);
    }
}
