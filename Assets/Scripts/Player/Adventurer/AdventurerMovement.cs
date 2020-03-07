using UnityEngine;

public class AdventurerMovement : MonoBehaviour, IPlayer
{
    [SerializeField] private float _runSpeed = 8;

    private Rigidbody _rb;
    private AdventurerState _state;

    private Vector2 _movePosition;
    private Vector2 _rotationPosition;

    private GameObject _circle;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _state = GetComponent<AdventurerState>();

        _circle = TransformExtension.GetChildObject(transform, "Direction").gameObject;
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
        if (_movePosition.magnitude > 0.25f)
        {
            Vector3 move = new Vector3(_movePosition.x, _rb.velocity.y, _movePosition.y);
            var moveVelocity = move * _runSpeed;
            _rb.MovePosition(_rb.position + moveVelocity * Time.fixedDeltaTime);
            RotateTowardsWalkeDirection(move);
        }
        else
        {
             _rb.velocity = new Vector3(0f,_rb.velocity.y,0f);
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
        if(_rotationPosition.magnitude > 0.25)
        {
            _circle.SetActive(true);
            _state.SetAimingState(true);
            Vector3 rotate = new Vector3(_rotationPosition.x, 0f, _rotationPosition.y);
            float angle = Vector3.Angle(Vector3.forward, rotate);
            angle = (rotate.x > 0) ? angle : angle * -1;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, angle, 0), 1f);
        }
        else
        {
            _state.SetAimingState(false);
            _circle.SetActive(false);
        }
    }

    public Vector2 ReturnMovePosition()
    {
        return _movePosition;
    }

    public void SetMovePosition(Vector2 input)
    {
        _movePosition = input;
    }

    public Vector2 ReturnRotationPosition()
    {
        return _rotationPosition;
    }

    public void SetRotationPosition(Vector2 input)
    {
        _rotationPosition = input;
    }

}
