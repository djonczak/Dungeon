using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float deadZone;
    private Rigidbody body;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 rotationPosition = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        if (rotationPosition.magnitude > deadZone)
        {
            float angle = Vector3.Angle(Vector3.back, rotationPosition);
            angle = (rotationPosition.x > 0) ? angle : angle * -1;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,angle,0), 1f);
            var characterMove = -transform.forward * moveSpeed * Time.deltaTime;
            body.MovePosition(transform.position + characterMove);
        }
        else
        {
            body.velocity = Vector3.zero;
        }
    }
}
