using UnityEngine;

public class AdventurerCityController : MonoBehaviour
{
    private InputController _controls;

    private void Awake()
    {
        var interact = GetComponent<PlayerInteract>();

        _controls = new InputController();
        _controls.Adventurer.Movement.performed += input => GetComponent<IPlayer>().SetMovePosition(input.ReadValue<Vector2>());
        _controls.Adventurer.Movement.canceled += input => GetComponent<IPlayer>().SetMovePosition(Vector2.zero);

        _controls.Adventurer.InteractablePress.performed += input => interact.InteractPress();
        _controls.Adventurer.InteractableHold.started += input => interact.holdButton = input.ReadValue<float>();
        _controls.Adventurer.InteractableHold.canceled += input => interact.holdButton = 0f;
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
