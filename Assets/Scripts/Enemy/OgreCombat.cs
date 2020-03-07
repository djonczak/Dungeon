using UnityEngine;

public class OgreCombat : StateMachineBehaviour
{
    [SerializeField] private Transform _target;
    private bool _canAttack = true;
    [SerializeField] private float _meleeRange;

    private int _lastAttack = 0;
    private int _randomAttack = 0;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _meleeRange = animator.GetBehaviour<AIFollow>().meleeRange;
        _target = animator.GetBehaviour<AIIdle>().GetTarget();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetComponent<LivingCreature>().isAlive)
        {
            if (_meleeRange >=  TransformExtension.DistanceBetween(animator.transform.position, _target.transform.position))
            {
                RotateTowards(animator);
                if (_canAttack == true)
                {
                    while (_lastAttack == _randomAttack)
                    {
                        _randomAttack = UnityEngine.Random.Range(1, 4);
                        Debug.Log(_randomAttack);
                    }
                    _lastAttack = _randomAttack;
                    _canAttack = false;
                    if (_randomAttack == 1)
                    {
                        animator.SetTrigger("SwingAttack");
                    }
                    if (_randomAttack == 2)
                    {
                        animator.SetTrigger("Punch1");
                    }
                    if (_randomAttack == 3)
                    {
                        animator.SetTrigger("Punch2");
                    }
                }

                if (animator.GetCurrentAnimatorStateInfo(0).IsName("OgreHorizontal") || animator.GetCurrentAnimatorStateInfo(0).IsName("OgrePunch") || animator.GetCurrentAnimatorStateInfo(0).IsName("OgreSwipe")) // check if "attack" is playing...
                {

                }
                else
                {
                    _canAttack = true;
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
        Quaternion rotation = Quaternion.LookRotation(_target.transform.position - animator.transform.position);
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
}
