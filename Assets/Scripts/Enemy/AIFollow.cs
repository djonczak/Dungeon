using UnityEngine;
using UnityEngine.AI;

public class AIFollow : StateMachineBehaviour
{
    public float moveSpeed;
    public float meleeRange;

    [SerializeField] private Transform _target;

    private NavMeshAgent _agent;
    private const string _combat = "IsCombat";
    private const string _follow = "IsFollow";

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent = animator.GetComponent<NavMeshAgent>();
        _target = animator.GetBehaviour<AIIdle>().GetTarget();

        animator.speed = 1f;
        _agent.speed = moveSpeed;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetComponent<LivingCreature>().isAlive == true)
        {
            _agent.SetDestination(_target.position);
            if (meleeRange >= TransformExtension.DistanceBetween(animator.transform.position, _target.transform.position))
            {
                animator.SetBool(_combat, true);
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       animator.SetBool(_follow, false);
    }
}
