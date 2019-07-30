using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkeeperControlls : MonoBehaviour
{
    public float walkSpeed;

    private InputController controls;
    public Vector2 move;
    [SerializeField] private Rigidbody rb;
    private Vector3 rotationPosition;

    private void FixedUpdate()
    {
        Movement();
    }

    public void Movement()
    {
        Vector3 movement = new Vector3(move.x, 0f, move.y);
        var moveVelocity = movement * walkSpeed;
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(move.x, 0f, move.y)), 0.15f);
    }

    private void Awake()
    {
        controls = new InputController();
        controls.InKeeper.Movement.performed += input => move = input.ReadValue<Vector2>();
        controls.InKeeper.Movement.canceled += input => move = Vector2.zero;
    }

    private void OnEnable()
    {
        controls.InKeeper.Enable();
    }

    private void OnDisable()
    {
        controls.InKeeper.Disable();
    }
}
