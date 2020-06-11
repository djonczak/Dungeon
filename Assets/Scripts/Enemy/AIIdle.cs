using UnityEngine;

public class AIIdle : StateMachineBehaviour
{
    [SerializeField] private float _visionRange = 5f;
    [SerializeField] private Transform _target;

    private const string _playerMask = "Player";
    private const string _follow = "IsFollow";
    private const string _idle = "IsIdle";

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.speed = Random.Range(0.1f, 1.5f);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_target == null)
        {
            var sphereVision = Physics.OverlapSphere(animator.gameObject.transform.position, _visionRange, LayerMask.GetMask(_playerMask));
            if (sphereVision.Length > 0)
            {
                _target = sphereVision[0].transform;
            }
        }
        else
        {
            animator.SetBool(_follow, true);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool(_idle, false);
    }

    public Transform GetTarget()
    {
        return _target;
    }
}
