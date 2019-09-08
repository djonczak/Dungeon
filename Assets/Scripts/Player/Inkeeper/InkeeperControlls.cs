using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkeeperControlls : MonoBehaviour
{
    public float walkSpeed;

    private InputController controls;
    public Vector2 move;
    private Rigidbody rb;
    private Vector3 rotationPosition;
    public Transform itemToPick;
    private float holdTime = 0f;
    private InteractableItem itemInteract;
    private bool canFill;
    private Transform beerKeg;
    private Animator anim;

    InkeeperInventory inventory;

    public TavernHUD hud;

    private void FixedUpdate()
    {
        Movement();
        FillMug();

        Interact();
    }

    private void FillMug()
    {
        if (canFill)
        {
            if (inventory.isUsingTray)
            {
                for (int i = 0; i < inventory.trey.GetComponent<Trey>().mugs.Count; i++)
                {
                    if (beerKeg.GetComponent<BeerKeg>().minAmount > 0)
                    {
                        hud.canFill = canFill;
                        holdTime = controls.InKeeper.Fill.ReadValue<float>();
                        if (holdTime == 1)
                        {
                            inventory.trey.GetComponent<Trey>().mugs[i].GetComponent<Mug>().FillMug(beerKeg.GetComponent<BeerKeg>());
                            hud.CloseFillCircle();
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else
            {
                for (int i = 0; i < inventory.mugs.Count; i++)
                {
                    if (beerKeg.GetComponent<BeerKeg>().minAmount > 0)
                    {
                        hud.canFill = canFill;
                        holdTime = controls.InKeeper.Fill.ReadValue<float>();
                        if (holdTime == 1)
                        {
                            inventory.mugs[i].GetComponent<Mug>().FillMug(beerKeg.GetComponent<BeerKeg>());
                            hud.CloseFillCircle();
                        }
                    }
                    else
                    {
                       return;
                    }
                }
            }
        }
    }

    public void Movement()
    {
        if (move.magnitude > 0.25f)
        {
            Vector3 movement = new Vector3(move.x, 0f, move.y);
            var moveVelocity = movement * walkSpeed;
            rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(move.x, 0f, move.y)), 0.15f);
            if (inventory.isUsingTray == true || inventory.mugs.Count != 0)
            {
                anim.SetBool("IsWalkingTrey", true);
            }
            else
            {
                anim.SetBool("IsWalking", true);
            }
            anim.SetBool("IsIdle", false);
            anim.SetBool("IsIdleTrey", false);
        }
        else
        {
            rb.velocity = Vector3.zero;
            if (inventory.isUsingTray == true || inventory.mugs.Count != 0)
            {
                anim.SetBool("IsIdleTrey", true);
                anim.SetBool("IsIdle", false);
            }
            else
            {
                anim.SetBool("IsIdle", true);
                anim.SetBool("IsIdleTrey", false);
            }
            anim.SetBool("IsWalking", false);
            anim.SetBool("IsWalkingTrey", false);
        }
    }

    private void Interact()
    {
        if (itemInteract != null)
        {
            holdTime = controls.InKeeper.Fill.ReadValue<float>();
            if (holdTime == 1)
            {
                InteractHold();
            }
        }
    }

    private void Awake()
    {
        controls = new InputController();
        // TODO: Getting vector2 from left stick to move player
        controls.InKeeper.Movement.performed += input => move = input.ReadValue<Vector2>();
        controls.InKeeper.Movement.canceled += input => move = Vector2.zero;

        // TODO: Picking object
        controls.InKeeper.PickUpItem.performed += input => PickItem();

        // TODO: Filling mugs near beer keg
        controls.InKeeper.Fill.started += input => hud.ShowFillCircle();
        controls.InKeeper.Fill.canceled += input => hud.CloseFillCircle();

        // TODO: Drop plate or mug
        controls.InKeeper.DropItem.performed += input => DropItem();

        // TODO: Interact with object
        controls.InKeeper.InteractablePress.performed += input => InteractPress();


    }

    private void Start()
    {
        inventory = GetComponent<InkeeperInventory>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void PickItem()
    {
        if (itemToPick != null)
        {
            inventory.PickItem(itemToPick);
            itemToPick = null;
            hud.CloseMessage();
        }
    }

    private void DropItem()
    {
        inventory.DropItem();
    }

    private void InteractPress()
    {
        if (itemInteract != null)
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
        if(other.tag == "Mug")
        {
            if (itemToPick == null && inventory.canCarry == true)
            {
                itemToPick = other.transform;
                other.GetComponent<InteractableItem>().ShowInfo();
                hud.ShowMessage(other.GetComponent<InteractableItem>().interactText);
            }
        }

        if (other.tag == "Keg")
        {
            if (other.GetComponent<BeerKeg>().minAmount > 0)
            {
                beerKeg = other.transform;
                canFill = true;
            }
        }

        if(other.tag == "Trey")
        {
            if (itemToPick == null)
            {
                other.GetComponent<InteractableItem>().ShowInfo();
                itemToPick = other.transform;
                hud.ShowMessage(other.GetComponent<InteractableItem>().interactText);
            }
        }

        if(other.tag == "Interactable")
        {
            var interact = other.GetComponent<InteractableItem>();
            if(interact != null)
            {
                interact.ShowInfo();
                itemInteract = interact;
                hud.ShowMessage(interact.interactText);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Keg")
        {
            hud.CloseFillCircle();
            canFill = false;
            beerKeg = null;
        }

        if (itemToPick != null && itemToPick.name == other.name)
        {
            itemToPick = null;
            hud.CloseMessage();
        }

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
