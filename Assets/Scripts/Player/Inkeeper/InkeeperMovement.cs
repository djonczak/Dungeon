using UnityEngine;

namespace Adventurer.Player
{
    public class InkeeperMovement : MonoBehaviour, IPlayer
    {
        [SerializeField] private float _walkSpeed = 5f;

        private Rigidbody _rb;
        private AdventurerState _state;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _state = GetComponent<AdventurerState>();
        }

        private void FixedUpdate()
        {
            Movement();
        }

        private void Movement()
        {
            if (_state.MoveVector.magnitude > 0.25f)
            {
                Vector3 movement = new Vector3(_state.MoveVector.x, 0f, _state.MoveVector.y).normalized;
                var moveVelocity = movement * _walkSpeed;
                _rb.MovePosition(_rb.position + moveVelocity * Time.fixedDeltaTime);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(_state.MoveVector.x, 0f, _state.MoveVector.y)), 0.15f);
            }
            else
            {
                _rb.velocity = Vector3.zero;
            }
        }

        public Vector2 ReturnMovePosition()
        {
            return _state.MoveVector;
        }

        public Vector2 ReturnRotationPosition()
        {
            return _state.MoveVector;
        }
    }
}
