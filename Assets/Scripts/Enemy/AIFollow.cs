using UnityEngine;
using UnityEngine.AI;

public class AIFollow : StateMachineBehaviour
{
    public float moveSpeed;
    public float meleeRange;
    [SerializeField] private Transform target;
    private NavMeshAgent agent;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        target = animator.GetBehaviour<AIIdle>().GetTarget();
        animator.speed = 1f;
        agent.speed = moveSpeed;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetComponent<LivingCreature>().isAlive == true)
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
