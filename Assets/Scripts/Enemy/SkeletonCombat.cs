using UnityEngine;

public class SkeletonCombat : StateMachineBehaviour
{
    private Transform _target;
    private bool _canAttack = true;
    private float _meleeRange;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _meleeRange = animator.GetBehaviour<AIFollow>().meleeRange;
        _target = animator.GetBehaviour<AIIdle>().GetTarget();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetComponent<MobHealth>().isAlive == true)
        {
            if (_meleeRange >= TransformExtension.DistanceBetween(animator.transform.position, _target.transform.position))
            {
                RotateTowards(animator);
                if (_canAttack == true)
                {
                    animator.SetTrigger("Melee");
                    _canAttack = false;
                }

                if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")) // check if "attack" is playing...
                {

                }
                else
                {
                    _canAttack = true;
                }
            }
            else
            {
                animator.SetBool("IsFollow", true);
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
        animator.SetBool("IsCombat", false);
    }
}


