using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurerController : MonoBehaviour
{
    private AdventurerCombat adventurerCombat;
    private AdventurerMovement adventurerMovement;
    private PlayerInteract interact;

    private InputController controls;

    private void Awake()
    {
        adventurerCombat = GetComponent<AdventurerCombat>();
        adventurerMovement = GetComponent<AdventurerMovement>();
        interact = GetComponent<PlayerInteract>();

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
        controls.Adventurer.InteractablePress.performed += input => interact.InteractPress();
        controls.Adventurer.InteractableHold.started += input => interact.holdButton = input.ReadValue<float>();
        controls.Adventurer.InteractableHold.canceled += input => interact.holdButton = 0f;
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
