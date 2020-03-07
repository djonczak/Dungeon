using UnityEngine;

public class AIIdle : StateMachineBehaviour
{
    [SerializeField] private float _visionRange = 5f;
    [SerializeField] private Transform _target;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.speed = Random.Range(0.1f, 1.5f);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_target == null)
        {
            var sphereVision = Physics.OverlapSphere(animator.gameObject.transform.position, _visionRange, LayerMask.GetMask("Player"));
            if (sphereVision.Length > 0)
            {
                _target = sphereVision[0].transform;
            }
        }
        else
        {
            animator.SetBool("IsFollow", true);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("IsIdle", false);
    }

    public Transform GetTarget()
    {
        return _target;
    }

}
