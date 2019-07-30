using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurerMovement : MonoBehaviour
{
    public float runSpeed;

    private Rigidbody rb;
    private Animator anim;
    private AdventurerState state;

    public Vector2 movePosition;
    public Vector2 rotationPosition;

    [SerializeField] private GameObject circle;

    private bool isAiming;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        state = GetComponent<AdventurerState>();
    }
   
    void FixedUpdate()
    {
        if (state.isAlive == true)
        {
            Move();
            Rotate();
        }
    }

    private void Move()
    {
        if (movePosition.magnitude > 0.25f)
        {
            Vector3 move = new Vector3(movePosition.x, 0F, movePosition.y);
            var moveVelocity = move * runSpeed;
            rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
            float angle = Vector3.Angle(Vector3.forward, move);
            angle = (move.x > 0) ? angle : angle * -1;
            transform.rotation = Quaternion.Euler(0, angle, 0);
            if (isAiming == false)
            {
                anim.SetFloat("VelNormal", Mathf.Abs(move.magnitude));
            }
        }
        else
        {
             rb.velocity = Vector3.zero;
             anim.SetFloat("VelNormal", Mathf.Abs(movePosition.magnitude));
        }
    }

    private void Rotate()
    {
        if(rotationPosition.magnitude > 0.25)
        {
            circle.SetActive(true);
            Vector3 rotate = new Vector3(rotationPosition.x, 0f, rotationPosition.y);
            float angle = Vector3.Angle(Vector3.forward, rotate);
            angle = (rotate.x > 0) ? angle : angle * -1;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, angle, 0), 1f);
            isAiming = true;
            anim.SetFloat("VelXCombat", movePosition.x);
            anim.SetFloat("VelYCombat", movePosition.y);
            if (state.isMelee == true)
            {
                anim.SetBool("IsSword", true);
                anim.SetBool("IsCrosbow", false);
            }
            else
            {
                anim.SetBool("IsSword", false);
                anim.SetBool("IsCrosbow", true);
            }
        }
        else
        {
            anim.SetBool("IsSword", false);
            anim.SetBool("IsCrosbow", false);
            isAiming = false;
            circle.SetActive(false);
        }
    }

}
