using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurerCityMovement : MonoBehaviour
{

    public float walkSpeed;
    public AdventurerHUD hud;

    private InputController controls;
    private Vector2 move;
    private Rigidbody rb;
    private Vector3 rotationPosition;

    private InteractableItem itemInteract;
    private Animator anim;

    private void Awake()
    {
        controls = new InputController();
        controls.InKeeper.Movement.performed += input => move = input.ReadValue<Vector2>();
        controls.InKeeper.Movement.canceled += input => move = Vector2.zero;

        controls.InKeeper.InteractablePress.performed += input => InteractPress();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        rb.freezeRotation = true;
    }


    private void FixedUpdate()
    {
        Movement();

        Interact();
    }

    private void Movement()
    {
        if (move.magnitude > 0.25f)
        {
            Vector3 movement = new Vector3(move.x, 0f, move.y);
            var moveVelocity = movement * walkSpeed;
            rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(move.x, 0f, move.y)), 0.15f);
            anim.SetFloat("VelNormal", Mathf.Abs(move.magnitude));
        }
        else
        {
            rb.velocity = Vector3.zero;
            anim.SetFloat("VelNormal", Mathf.Abs(move.magnitude));

        }
    }

    private void Interact()
    {
        if (itemInteract != null)
        {
            var holdTime = controls.InKeeper.Fill.ReadValue<float>();
            if (holdTime == 1)
            {
                InteractHold();
            }
        }
    }

    void InteractPress()
    {
        if(itemInteract != null)
        {
            itemInteract.OnInteractPress();
        }
    }

    private void InteractHold()
    {
        if (itemInteract != null)
        {
            itemInteract.OnInteractHold();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Interactable")
        {
            var interact = other.GetComponent<InteractableItem>();
            if (interact != null)
            {
                interact.ShowInfo();
                itemInteract = interact;
                hud.ShowMessage(interact.interactText);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Interactable")
        {
            hud.CloseMessage();
            itemInteract = null;
        }
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
