using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkeeperAnimations : MonoBehaviour
{
    private Animator anim;
    private InkeeperMovement inkeeperMove;
    private InkeeperInventory inventory;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        inventory = GetComponent<InkeeperInventory>();
        inkeeperMove = GetComponent<InkeeperMovement>();
    }

    private void Update()
    {
        if (inkeeperMove.movePosition.magnitude > 0.25f)
        {
            if (inventory.CheckTrey() == true || inventory.mugs.Count != 0)
            {
                anim.SetBool("IsWalkingTrey", true);
                anim.SetBool("IsWalking", false);
            }
            else
            {
                anim.SetBool("IsWalking", true);
                anim.SetBool("IsWalkingTrey", false);
            }
            anim.SetBool("IsIdle", false);
            anim.SetBool("IsIdleTrey", false);
        }
        else
        {
            if (inventory.CheckTrey() == true || inventory.mugs.Count != 0)
            {
                anim.SetBool("IsIdleTrey", true);
                anim.SetBool("IsIdle", false);
            }
            else
            {
                anim.SetBool("IsIdle", true);
                anim.SetBool("IsIdleTrey", false);
            }
            anim.SetBool("IsWalking", false);
            anim.SetBool("IsWalkingTrey", false);
        }
    }
}
