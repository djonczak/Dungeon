using UnityEngine;

public class AdventurerCityController : MonoBehaviour
{
    private InputController controls;

    private PlayerInteract interact;
    private AdventurerMovement movement;

    private void Awake()
    {
        interact = GetComponent<PlayerInteract>();
        movement = GetComponent<AdventurerMovement>();

        controls = new InputController();
        controls.Adventurer.Movement.performed += input => movement.movePosition = input.ReadValue<Vector2>();
        controls.Adventurer.Movement.canceled += input => movement.movePosition = Vector2.zero;

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
