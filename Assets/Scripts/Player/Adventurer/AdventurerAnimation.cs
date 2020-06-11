using UnityEngine;

namespace Adventurer.Player
{
    public class AdventurerAnimation : MonoBehaviour
    {
        private AdventurerState _state;
        private Animator _anim;

        private Vector2 _animationVector;

        private const string _velNormal = "VelNormal";
        private const string _velXCombat = "VelXCombat";
        private const string _velYCombat = "VelYCombat";
        private const string _sword = "IsSword";
        private const string _crossbow = "IsCrossbow";
        private const string _melee = "Melee";

        private void Awake()
        {
            _anim = GetComponent<Animator>();
            _state = GetComponent<AdventurerState>();
        }

        private void Update()
        {
            _animationVector = GetComponent<IPlayer>().ReturnMovePosition();
            MoveAnimation(_animationVector);
            WeaponAimingAnimation(_animationVector);
        }

        private void MoveAnimation(Vector2 playerPosition)
        {
            if (_state.Aiming == false)
            {
                if (playerPosition.magnitude > 0.25f)
                {
                    _anim.SetFloat(_velNormal, Mathf.Abs(playerPosition.magnitude));
                }
                else
                {
                    _anim.SetFloat(_velNormal, Mathf.Abs(playerPosition.magnitude));
                }
            }
        }

        private void WeaponAimingAnimation(Vector2 playerPosition)
        {
            if (_state.Aiming == true)
            {
                _anim.SetFloat(_velXCombat, playerPosition.x);
                _anim.SetFloat(_velYCombat, playerPosition.y);
                if (_state.MeleeState == true)
                {
                    _anim.SetBool(_sword, true);
                    _anim.SetBool(_crossbow, false);
                }
                else
                {
                    _anim.SetBool(_sword, false);
                    _anim.SetBool(_crossbow, true);
                }
            }
            else
            {
                _anim.SetBool(_sword, false);
                _anim.SetBool(_crossbow, false);
            }
        }

        public void MeleeAttackAnimation(int animationNumber)
        {
            _anim.SetTrigger(_melee + animationNumber);
        }
    }
}
