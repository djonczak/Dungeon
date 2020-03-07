using UnityEngine;

public class InkeeperMovement : MonoBehaviour, IPlayer
{
    [SerializeField] private float _walkSpeed = 5f;

    private Rigidbody _rb;
    private Vector2 _position;
    private Vector2 _rotation;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        if (_position.magnitude > 0.25f)
        {
            Vector3 movement = new Vector3(_position.x, 0f, _position.y).normalized;
            var moveVelocity = movement * _walkSpeed;
            _rb.MovePosition(_rb.position + moveVelocity * Time.fixedDeltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(_position.x, 0f, _position.y)), 0.15f);
        }
        else
        {
            _rb.velocity = Vector3.zero;
        }
    }

    public Vector2 ReturnMovePosition()
    {
        return _position;
    }

    public void SetMovePosition(Vector2 input)
    {
        _position = input;
    }

    public Vector2 ReturnRotationPosition()
    {
        return _rotation;
    }

    public void SetRotationPosition(Vector2 input)
    {
        _rotation = input;
    }
}
