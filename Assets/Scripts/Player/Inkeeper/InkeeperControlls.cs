using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkeeperControlls : MonoBehaviour
{
    private InputController controls;
    private bool canFill;
    private Transform beerKeg;

    public TavernHUD hud;
    private InkeeperMovement move;
    private InkeeperPickObject pickObject;
    private PlayerInteract interact;

    private void Awake()
    {
        move = GetComponent<InkeeperMovement>();
        pickObject = GetComponent<InkeeperPickObject>();
        interact = GetComponent<PlayerInteract>();

        controls = new InputController();
        // TODO: Getting vector2 from left stick to move player
        controls.InKeeper.Movement.performed += input => move.movePosition = input.ReadValue<Vector2>();
        controls.InKeeper.Movement.canceled += input => move.movePosition = Vector2.zero;

        // TODO: Picking object
        controls.InKeeper.PickUpItem.performed += input => pickObject.PickItem();

        // TODO: Filling mugs near beer keg
        //controls.InKeeper.Fill.started += input => hud.ShowFillCircle();
        //controls.InKeeper.Fill.canceled += input => hud.CloseFillCircle();

        // TODO: Drop plate or mug
        controls.InKeeper.DropItem.performed += input => DropItem();

        // TODO: Interact with object
        controls.InKeeper.InteractablePress.performed += input => interact.InteractPress();
        controls.InKeeper.InteractableHold.started += input => interact.holdButton = input.ReadValue<float>();
        controls.InKeeper.InteractableHold.canceled += input => interact.holdButton = 0f;
    }

    //private void FillMug()
    //{
    //    if (canFill)
    //    {
    //       // if (inventory.CheckTrey())
    //        {
    //       //     for (int i = 0; i < inventory.trey.GetComponent<Trey>().mugs.Count; i++)
    //            {
    //                if (beerKeg.GetComponent<BeerKeg>().minAmount > 0)
    //                {
    //                    hud.canFill = canFill;
    //                    holdTime = controls.InKeeper.Fill.ReadValue<float>();
    //                    if (holdTime == 1)
    //                    {
    //              //          inventory.trey.GetComponent<Trey>().mugs[i].GetComponent<Mug>().FillMug(beerKeg.GetComponent<BeerKeg>());
    //                        hud.CloseFillCircle();
    //                    }
    //                }
    //                else
    //                {
    //                    return;
    //                }
    //            }
    //        }
    //        else
    //        {
    //            for (int i = 0; i < inventory.mugs.Count; i++)
    //            {
    //                if (beerKeg.GetComponent<BeerKeg>().minAmount > 0)
    //                {
    //                    hud.canFill = canFill;
    //                    holdTime = controls.InKeeper.Fill.ReadValue<float>();
    //                    if (holdTime == 1)
    //                    {
    //                        inventory.mugs[i].GetComponent<Mug>().FillMug(beerKeg.GetComponent<BeerKeg>());
    //                        hud.CloseFillCircle();
    //                    }
    //                }
    //                else
    //                {
    //                   return;
    //                }
    //            }
    //        }
    //    }
    //}

    private void DropItem()
    {
       // inventory.DropItem();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Keg")
        {
            if (other.GetComponent<BeerKeg>().minAmount > 0)
            {
                beerKeg = other.transform;
                canFill = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Barrel")
        {
           
            hud.CloseMessage();
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
