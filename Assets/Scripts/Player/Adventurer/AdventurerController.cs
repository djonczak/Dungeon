using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurerController : MonoBehaviour
{
    [SerializeField] private AdventurerCombat adventurerCombat;
    [SerializeField] private AdventurerState state;
    [SerializeField] private AdventurerMovement adventurerMovement;

    public AdventurerHUD hud;

    private InputController controls;
    private GameObject interactableItem;

    private void Start()
    {
        adventurerCombat = GetComponent<AdventurerCombat>();
        adventurerMovement = GetComponent<AdventurerMovement>();
        state = GetComponent<AdventurerState>();
    }

    private void Awake()
    {
        controls = new InputController();

        //Movement
        controls.Adventurer.Movement.performed += input => adventurerMovement.movePosition = input.ReadValue<Vector2>();
        controls.Adventurer.Movement.canceled += input => adventurerMovement.movePosition = Vector2.zero;

        //Rotate
        controls.Adventurer.Rotate.performed += input => adventurerMovement.rotationPosition = input.ReadValue<Vector2>();
        controls.Adventurer.Rotate.canceled += input => adventurerMovement.rotationPosition = Vector2.zero;

        //Combat
        controls.Adventurer.Attack.performed += input => adventurerCombat.Attack();
        controls.Adventurer.SwitchWeapon.performed += input => adventurerCombat.SwitchWeapon();

        //Interact
        controls.Adventurer.Interactable.performed += input => Interact(); 
    }

    private void Interact()
    {
        if(interactableItem != null)
        {
            interactableItem.GetComponent<InteractableItem>().OnInteractPress();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Interactable")
        {
            interactableItem = other.gameObject;
            interactableItem.GetComponent<InteractableItem>().ShowInfo();
            hud.ShowMessage(interactableItem.GetComponent<InteractableItem>().interactText);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Interactable")
        {
            interactableItem = null;
            hud.CloseMessage();
        }
    }

    private void OnEnable()
    {
        controls.Adventurer.Enable();
    }

    private void OnDisable()
    {
        controls.Adventurer.Disable();
    }
}
