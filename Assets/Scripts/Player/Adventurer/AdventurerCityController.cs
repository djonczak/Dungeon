using UnityEngine;

namespace Adventurer.Player
{
    public class AdventurerCityController : MonoBehaviour
    {
        private InputController _controls;

        private void Awake()
        {
            _controls = new InputController();

            var interact = GetComponent<PlayerInteract>();
            var adventurer = GetComponent<AdventurerState>();

            //Movement
            _controls.Adventurer.Movement.performed += input => adventurer.MoveVector = input.ReadValue<Vector2>();
            _controls.Adventurer.Movement.canceled += input => adventurer.MoveVector = Vector2.zero;

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
}
