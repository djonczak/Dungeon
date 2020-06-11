using UnityEngine;

namespace Adventurer.Player
{
    public class InkeeperMovement : MonoBehaviour, IPlayer
    {
        [SerializeField] private float _walkSpeed = 5f;

        private Rigidbody _rb;
        private Adventurer _adventurer;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _adventurer = gameObject.AddComponent<Adventurer>();
        }

        private void FixedUpdate()
        {
            Movement();
        }

        private void Movement()
        {
            if (_adventurer.MoveVector.magnitude > 0.25f)
            {
                Vector3 movement = new Vector3(_adventurer.MoveVector.x, 0f, _adventurer.MoveVector.y).normalized;
                var moveVelocity = movement * _walkSpeed;
                _rb.MovePosition(_rb.position + moveVelocity * Time.fixedDeltaTime);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(_adventurer.MoveVector.x, 0f, _adventurer.MoveVector.y)), 0.15f);
            }
            else
            {
                _rb.velocity = Vector3.zero;
            }
        }

        public Vector2 ReturnMovePosition()
        {
            return _adventurer.MoveVector;
        }

        public Vector2 ReturnRotationPosition()
        {
            return _adventurer.MoveVector;
        }

        public Adventurer GetAdventurer()
        {
            return _adventurer;
        }
    }
}
