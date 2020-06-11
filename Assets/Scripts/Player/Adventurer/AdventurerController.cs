using UnityEngine;

namespace Adventurer.Player
{
    public class AdventurerController : MonoBehaviour
    {
        private InputController _controls;

        private void Awake()
        {
            _controls = new InputController();

            var adventurerInteract = GetComponent<PlayerInteract>();
            var adventurerCombat = GetComponent<AdventurerCombat>();
            var adventurer = GetComponent<AdventurerState>();

            //Movement
            _controls.Adventurer.Movement.performed += input => adventurer.MoveVector = input.ReadValue<Vector2>();
            _controls.Adventurer.Movement.canceled += input => adventurer.MoveVector = Vector2.zero;

            //Rotate
            _controls.Adventurer.Rotate.performed += input => adventurer.RotationVector = input.ReadValue<Vector2>();
            _controls.Adventurer.Rotate.canceled += input => adventurer.RotationVector = Vector2.zero;

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
}
