using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurerController : MonoBehaviour
{
    [SerializeField] private AdventurerCombat adventurerCombat;
    [SerializeField] private AdventurerState state;
    [SerializeField] private AdventurerMovement adventurerMovement;

    private InputController controls;

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
