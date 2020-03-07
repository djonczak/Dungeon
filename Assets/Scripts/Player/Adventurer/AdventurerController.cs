using UnityEngine;

public class AdventurerController : MonoBehaviour
{
    private InputController _controls;

    private void Awake()
    {
        _controls = new InputController();

        var adventurerInteract = GetComponent<PlayerInteract>();
        var adventurerCombat = GetComponent<AdventurerCombat>();

        //Movement
        _controls.Adventurer.Movement.performed += input => GetComponent<IPlayer>().SetMovePosition(input.ReadValue<Vector2>());
        _controls.Adventurer.Movement.canceled += input => GetComponent<IPlayer>().SetMovePosition(Vector2.zero);

        //Rotate
        _controls.Adventurer.Rotate.performed += input => GetComponent<IPlayer>().SetRotationPosition(input.ReadValue<Vector2>());
        _controls.Adventurer.Rotate.canceled += input => GetComponent<IPlayer>().SetRotationPosition(Vector2.zero);

        //Combat
        _controls.Adventurer.Attack.performed += input => adventurerCombat.Attack();
        _controls.Adventurer.SwitchWeapon.performed += input => adventurerCombat.SwitchWeapon();

        //Interact
        _controls.Adventurer.InteractablePress.performed += input => adventurerInteract.InteractPress();
        _controls.Adventurer.InteractableHold.started += input => adventurerInteract.holdButton = input.ReadValue<float>();
        _controls.Adventurer.InteractableHold.canceled += input => adventurerInteract.holdButton = 0f;
    }

    private void OnEnable()
    {
        _controls.Adventurer.Enable();
    }

    private void OnDisable()
    {
        _controls.Adventurer.Disable();
    }
}
