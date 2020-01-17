using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//public class myscript : monobehaviour
//{
//    void onenable()
//    {
//        skeletoncombat.attackreset += docoroutine;
//    }

//    void ondisable()
//    {
//        skeletoncombat.attackreset -= docoroutine;
//    }

//    void docoroutine()
//    {
//        startcoroutine("resumeattack", 1.5f);
//    }

//    ienumerator resumeattack(float time)
//    {
//        debug.log("icyk");
//        yield return new waitforseconds(time);
//        getcomponent<animator>().getbehaviour<skeletoncombat>().canattack = true;
//    }
//}

public class SkeletonCombat : StateMachineBehaviour
{
  //  public delegate void ResetAttack();
  //  public static event ResetAttack AttackReset;

    private Transform target;
    private NavMeshAgent agent;
    private bool canAttack = true;
    private float meleeRange;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        meleeRange = animator.GetBehaviour<AIFollow>().meleeRange;
        target = animator.GetBehaviour<AIFollow>().target;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetComponent<MobHealth>().isAlive == true)
        {
            if (meleeRange >= TransformExtension.DistanceBetween(animator.transform.position,target.transform.position))
            {
                Quaternion rotation = Quaternion.LookRotation(target.transform.position - animator.transform.position);
                rotation.x = 0;
                rotation.z = 0;
                animator.transform.rotation = Quaternion.Slerp(animator.transform.rotation, rotation, 10f * Time.deltaTime);
                if (canAttack == true)
                {
                    animator.SetTrigger("Melee");
                    canAttack = false;
                }

                if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")) // check if "attack" is playing...
                {

                }
                else
                {
                    canAttack = true;
                   // AttackReset();
                }
            }
            else
            {
                animator.SetBool("IsFollow", true);
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("IsCombat", false);
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


