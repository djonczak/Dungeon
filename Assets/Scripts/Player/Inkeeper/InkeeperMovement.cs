using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkeeperMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 5f;

    public Vector2 movePosition;

    private Rigidbody rb;
    private Vector3 rotationPosition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        if (movePosition.magnitude > 0.25f)
        {
            Vector3 movement = new Vector3(movePosition.x, 0f, movePosition.y);
            var moveVelocity = movement * walkSpeed;
            rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(movePosition.x, 0f, movePosition.y)), 0.15f);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
}
