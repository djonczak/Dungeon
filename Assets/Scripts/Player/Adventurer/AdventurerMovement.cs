using UnityEngine;

namespace Adventurer.Player
{
    public class AdventurerMovement : MonoBehaviour
    {
        [SerializeField] private float _runSpeed = 8;

        private Rigidbody _rb;
        private AdventurerState _adventurer;
        private GameObject _circle;

        private const string _circleName = "Direction";

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _adventurer = GetComponent<AdventurerState>();

            _circle = TransformExtension.GetChildObject(this.gameObject, _circleName);
        }

        private void Start()
        {
            _rb.freezeRotation = true;
        }

        private void FixedUpdate()
        {
            Move();
            Rotate();
        }

        private void Move()
        {
            if (_adventurer.MoveVector.magnitude > 0.25f)
            {
                Vector3 move = new Vector3(_adventurer.MoveVector.x, _rb.velocity.y, _adventurer.MoveVector.y);
                var moveVelocity = move * _runSpeed;
                _rb.MovePosition(_rb.position + moveVelocity * Time.fixedDeltaTime);
                RotateTowardsWalkeDirection(move);
            }
            else
            {
                _rb.velocity = new Vector3(0f, _rb.velocity.y, 0f);
            }
        }

        private void RotateTowardsWalkeDirection(Vector3 move)
        {
            float angle = Vector3.Angle(Vector3.forward, move);
            angle = (move.x > 0) ? angle : angle * -1;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, angle, 0), 1f);
        }

        private void Rotate()
        {
            if (_adventurer.RotationVector.magnitude > 0.25)
            {
                _circle.SetActive(true);
                _adventurer.Aiming = true;

                Vector3 rotate = new Vector3(_adventurer.RotationVector.x, 0f, _adventurer.RotationVector.y);
                float angle = Vector3.Angle(Vector3.forward, rotate);
                angle = (rotate.x > 0) ? angle : angle * -1;

                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, angle, 0), 1f);
            }
            else
            {
                _adventurer.Aiming = false;
                _circle.SetActive(false);
            }
        }
    }
}
