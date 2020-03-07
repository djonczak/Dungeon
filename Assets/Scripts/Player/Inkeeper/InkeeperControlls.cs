using UnityEngine;

public class InkeeperControlls : MonoBehaviour
{
    private InputController _controls;
    private bool canFill;
    private Transform beerKeg;

    private void Awake()
    {
        var pickingObject = GetComponent<InkeeperPickObject>();
        var interact = GetComponent<PlayerInteract>();

        _controls = new InputController();
        // TODO: Getting vector2 from left stick to move player
        _controls.InKeeper.Movement.performed += input => GetComponent<IPlayer>().SetMovePosition(input.ReadValue<Vector2>());
        _controls.InKeeper.Movement.canceled += input => GetComponent<IPlayer>().SetMovePosition(Vector2.zero);

        // TODO: Picking object
        _controls.InKeeper.PickUpItem.performed += input => pickingObject.PickItem();

        // TODO: Filling mugs near beer keg
        //controls.InKeeper.Fill.started += input => hud.ShowFillCircle();
        //controls.InKeeper.Fill.canceled += input => hud.CloseFillCircle();

        // TODO: Drop plate or mug
        _controls.InKeeper.DropItem.performed += input => DropItem();

        // TODO: Interact with object
        _controls.InKeeper.InteractablePress.performed += input => interact.InteractPress();
        _controls.InKeeper.InteractableHold.started += input => interact.holdButton = input.ReadValue<float>();
        _controls.InKeeper.InteractableHold.canceled += input => interact.holdButton = 0f;
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
           
          //  hud.CloseMessage();
        }
    }

    private void OnEnable()
    {
        _controls.InKeeper.Enable();
    }

    private void OnDisable()
    {
        _controls.InKeeper.Disable();
    }
}
