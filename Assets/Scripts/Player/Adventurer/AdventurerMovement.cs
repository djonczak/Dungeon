using UnityEngine;

public class AdventurerMovement : MonoBehaviour
{
    [SerializeField] private float runSpeed = 8;

    private Rigidbody rb;
    private AdventurerState state;

    public Vector2 movePosition;
    public Vector2 rotationPosition;

    [SerializeField]private GameObject circle;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        state = GetComponent<AdventurerState>();

        circle = TransformExtension.GetChildObject(transform, "Direction").gameObject;
    }

    private void Start()
    {
        rb.freezeRotation = true;
    }
   
    private void FixedUpdate()
    {
         Move();
         Rotate();
    }

    private void Move()
    {
        if (movePosition.magnitude > 0.25f)
        {
            Vector3 move = new Vector3(movePosition.x, rb.velocity.y, movePosition.y);
            var moveVelocity = move * runSpeed;
            rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
            RotateTowardsWalkeDirection(move);
        }
        else
        {
             rb.velocity = new Vector3(0f,rb.velocity.y,0f);
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
        if(rotationPosition.magnitude > 0.25)
        {
            circle.SetActive(true);
            state.isAiming = true;
            Vector3 rotate = new Vector3(rotationPosition.x, 0f, rotationPosition.y);
            float angle = Vector3.Angle(Vector3.forward, rotate);
            angle = (rotate.x > 0) ? angle : angle * -1;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, angle, 0), 1f);
        }
        else
        {
            state.isAiming = false;
            circle.SetActive(false);
        }
    }

}
