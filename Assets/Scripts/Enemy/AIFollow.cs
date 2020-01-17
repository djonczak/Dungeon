using UnityEngine;
using UnityEngine.AI;

public class AIFollow : StateMachineBehaviour
{
    public Transform target;
    public float moveSpeed;
    private NavMeshAgent agent;
    public float meleeRange;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        animator.speed = 1f;
        agent.speed = moveSpeed;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetComponent<MobHealth>().isAlive == true)
        {
            agent.SetDestination(target.position);
            if (meleeRange >= TransformExtension.DistanceBetween(animator.transform.position,target.transform.position))
            {
                animator.SetBool("IsCombat", true);
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       animator.SetBool("IsFollow", false);
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
