using UnityEngine;

public class AIIdle : StateMachineBehaviour
{
    [SerializeField] private float visionRange = 5f;
    [SerializeField] private Transform target;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.speed = Random.Range(0.1f, 1.5f);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (target == null)
        {
            var sphereVision = Physics.OverlapSphere(animator.gameObject.transform.position, visionRange, LayerMask.GetMask("Player"));
            if (sphereVision.Length > 0)
            {
                target = sphereVision[0].transform;
            }
        }
        else
        {
            animator.SetBool("IsFollow", true);
            //foreach(AIFollow follow in animator.GetBehaviours<AIFollow>())
            //{
            //    follow.PassTarget(target);
            //}
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("IsIdle", false);
    }

    public Transform GetTarget()
    {
        return target;
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
