using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float acceleration;
    public float deadZone;

    private Rigidbody body;
    private float currentSpeed = 2f;
    private Animator anim;
    private AdventurerState state;
    private bool isDashing;
    private bool canDash = true;
    private Vector3 dashPosition;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        state = GetComponent<AdventurerState>();
    }
   
    void FixedUpdate()
    {
        if (state.isAlive == true)
        {
            Move();
            Dash();
        }
    }

    private void Move()
    {
        if (isDashing == false)
        {
            Vector3 rotationPosition = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

            if (rotationPosition.magnitude > deadZone && state.isAttacking == false && isDashing == false)
            {
                float angle = Vector3.Angle(Vector3.back, rotationPosition);
                angle = (rotationPosition.x > 0) ? angle : angle * -1;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, angle, 0), 1f);
                if (currentSpeed <= moveSpeed)
                {
                    currentSpeed += Time.deltaTime * acceleration;
                }
                var characterMove = -transform.forward * currentSpeed * Time.deltaTime;
                body.MovePosition(transform.position + characterMove);
                anim.SetBool("IsRun", true);
                anim.SetBool("IsIdle", false);
            }

            if(state.isAttacking == true && rotationPosition.magnitude > deadZone)
            {
                float angle = Vector3.Angle(Vector3.back, rotationPosition);
                angle = (rotationPosition.x > 0) ? angle : angle * -1;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, angle, 0), 1f);
            }

            if (rotationPosition.magnitude < deadZone)
            {
                if (state.isAttacking == false)
                {
                    anim.SetBool("IsIdle", true);
                    anim.SetBool("IsRun", false);
                }
                currentSpeed = 2f;
                body.velocity = Vector3.zero;
            }
        }
    }

    private void Dash()
    {
        if (canDash == true)
        {
            dashPosition = new Vector3(Input.GetAxis("DashX"), 0f, Input.GetAxis("DashY"));
        }

        if (dashPosition.magnitude > 1f && state.isAttacking == false)
        {
            if (canDash == true)
            {
                isDashing = true;
            }
        }

        if(isDashing == true)
        {
            var dashMove = dashPosition * 14f * Time.deltaTime;
            body.MovePosition(transform.position + dashMove);
            if (canDash == true)
            {
                StartCoroutine("DashCooldown", 1f);
            }
        }

    }

    private IEnumerator DashCooldown(float time)
    {
        anim.SetTrigger("IsDodge");
        canDash = false;
        yield return new WaitForSeconds(0.3f);
        isDashing = false;
        yield return new WaitForSeconds(time);
        canDash = true;
    }
}
