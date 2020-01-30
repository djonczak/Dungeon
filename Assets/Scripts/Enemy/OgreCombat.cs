﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OgreCombat : StateMachineBehaviour
{
    public Transform target;
    public bool canAttack = true;
    private float meleeRange;

    private int lastAttack = 0;
    private int randomAttack = 0;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        meleeRange = animator.GetBehaviour<AIFollow>().meleeRange;
        target = animator.GetBehaviour<AIIdle>().GetTarget();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetComponent<LivingCreature>().isAlive)
        {
            if (meleeRange >=  TransformExtension.DistanceBetween(animator.transform.position,target.transform.position))
            {
                RotateTowards(animator);
                if (canAttack == true)
                {
                    while (lastAttack == randomAttack)
                    {
                        randomAttack = UnityEngine.Random.Range(1, 4);
                        Debug.Log(randomAttack);
                    }
                    lastAttack = randomAttack;
                    canAttack = false;
                    if (randomAttack == 1)
                    {
                        animator.SetTrigger("SwingAttack");
                    }
                    if (randomAttack == 2)
                    {
                        animator.SetTrigger("Punch1");
                    }
                    if (randomAttack == 3)
                    {
                        animator.SetTrigger("Punch2");
                    }
                }

                if (animator.GetCurrentAnimatorStateInfo(0).IsName("OgreHorizontal") || animator.GetCurrentAnimatorStateInfo(0).IsName("OgrePunch") || animator.GetCurrentAnimatorStateInfo(0).IsName("OgreSwipe")) // check if "attack" is playing...
                {

                }
                else
                {
                    canAttack = true;
                }
            }
            else
            {
                animator.SetBool("IsCombat", false);
                if (animator.GetComponent<OgreHealth>().phase == OgreHealth.HPState.Full)
                {
                    animator.SetBool("IsRun", false);
                    animator.SetBool("IsFollow", true);

                }
                else
                {
                    animator.SetBool("IsFollow", false);
                    animator.SetBool("IsRun", true);
                }
            }
        }
    }

    private void RotateTowards(Animator animator)
    {
        Quaternion rotation = Quaternion.LookRotation(target.transform.position - animator.transform.position);
        rotation.x = 0;
        rotation.z = 0;
        animator.transform.rotation = Quaternion.Slerp(animator.transform.rotation, rotation, 10f * Time.deltaTime);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Punch1");
        animator.ResetTrigger("Punch2");
        animator.ResetTrigger("SwingAttack");
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
