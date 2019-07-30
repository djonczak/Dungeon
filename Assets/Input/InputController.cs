// GENERATED AUTOMATICALLY FROM 'Assets/Input/InputController.inputactions'

using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class InputController : IInputActionCollection
{
    private InputActionAsset asset;
    public InputController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputController"",
    ""maps"": [
        {
            ""name"": ""InKeeper"",
            ""id"": ""db1c99cf-f4b3-4fba-950b-dbe2dee8ec81"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""c8c16370-6a0c-4572-8cb2-e10afe8ceba7"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": ""AxisDeadzone(min=0.19,max=0.9)"",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e0d5f2b9-6cac-4a1b-8e29-614faab30c27"",
                    ""path"": ""<DualShockGamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1fd01760-dcbd-450b-a263-e99d0e9fb49a"",
                    ""path"": ""<SwitchProControllerHID>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cff8aa30-5148-4ef9-80c7-6824767bfb2f"",
                    ""path"": ""<XInputController>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Adventurer"",
            ""id"": ""3bf226c3-d9bc-4eda-b3ee-ec839a907d8e"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""d8f2f013-a1ad-4027-ad1a-4a04aec3d70f"",
                    ""expectedControlType"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""98d6f6bd-333c-4396-8ae2-a990cdf5aed2"",
                    ""expectedControlType"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""32fde26e-e6a4-4db2-b972-ccef09154ce1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""SwitchWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""595ce809-d12f-4098-ac10-0f29c23c6ebb"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""47728d0d-c143-40db-b1fc-6f0cf280aaca"",
                    ""path"": ""<XInputController>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f1f41bd-334e-49f7-ab17-6d997bd1d79d"",
                    ""path"": ""<SwitchProControllerHID>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""64e9f92a-1e18-4f7c-ba25-4ca4ec123ef8"",
                    ""path"": ""<DualShockGamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9111de7b-20e6-4479-b2cc-a1f0487948af"",
                    ""path"": ""<DualShockGamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""65895b6c-3b14-4802-8e78-1623cbb9ef90"",
                    ""path"": ""<SwitchProControllerHID>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""058d8203-e5f5-4b40-9de5-c22cad79f49b"",
                    ""path"": ""<SwitchProControllerHID>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c8e59857-baf3-4d3a-811c-29dd708311a8"",
                    ""path"": ""<DualShockGamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""edf28000-377e-44a2-aeea-ac2b12cfeb2f"",
                    ""path"": ""<SwitchProControllerHID>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e360cef6-09d0-4b6a-931e-797024ed7eda"",
                    ""path"": ""<XInputController>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""54d4a46b-ae08-457f-bc2d-f6fc343a0b5f"",
                    ""path"": ""<DualShockGamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2b8a7def-4ba0-4f83-8f5b-3552ea36140e"",
                    ""path"": ""<SwitchProControllerHID>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""771abaa3-eb16-4aa8-9596-abc628ca072e"",
                    ""path"": ""<XInputController>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // InKeeper
        m_InKeeper = asset.GetActionMap("InKeeper");
        m_InKeeper_Movement = m_InKeeper.GetAction("Movement");
        // Adventurer
        m_Adventurer = asset.GetActionMap("Adventurer");
        m_Adventurer_Movement = m_Adventurer.GetAction("Movement");
        m_Adventurer_Rotate = m_Adventurer.GetAction("Rotate");
        m_Adventurer_Attack = m_Adventurer.GetAction("Attack");
        m_Adventurer_SwitchWeapon = m_Adventurer.GetAction("SwitchWeapon");
    }

    ~InputController()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // InKeeper
    private readonly InputActionMap m_InKeeper;
    private IInKeeperActions m_InKeeperActionsCallbackInterface;
    private readonly InputAction m_InKeeper_Movement;
    public struct InKeeperActions
    {
        private InputController m_Wrapper;
        public InKeeperActions(InputController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_InKeeper_Movement;
        public InputActionMap Get() { return m_Wrapper.m_InKeeper; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InKeeperActions set) { return set.Get(); }
        public void SetCallbacks(IInKeeperActions instance)
        {
            if (m_Wrapper.m_InKeeperActionsCallbackInterface != null)
            {
                Movement.started -= m_Wrapper.m_InKeeperActionsCallbackInterface.OnMovement;
                Movement.performed -= m_Wrapper.m_InKeeperActionsCallbackInterface.OnMovement;
                Movement.canceled -= m_Wrapper.m_InKeeperActionsCallbackInterface.OnMovement;
            }
            m_Wrapper.m_InKeeperActionsCallbackInterface = instance;
            if (instance != null)
            {
                Movement.started += instance.OnMovement;
                Movement.performed += instance.OnMovement;
                Movement.canceled += instance.OnMovement;
            }
        }
    }
    public InKeeperActions @InKeeper => new InKeeperActions(this);

    // Adventurer
    private readonly InputActionMap m_Adventurer;
    private IAdventurerActions m_AdventurerActionsCallbackInterface;
    private readonly InputAction m_Adventurer_Movement;
    private readonly InputAction m_Adventurer_Rotate;
    private readonly InputAction m_Adventurer_Attack;
    private readonly InputAction m_Adventurer_SwitchWeapon;
    public struct AdventurerActions
    {
        private InputController m_Wrapper;
        public AdventurerActions(InputController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Adventurer_Movement;
        public InputAction @Rotate => m_Wrapper.m_Adventurer_Rotate;
        public InputAction @Attack => m_Wrapper.m_Adventurer_Attack;
        public InputAction @SwitchWeapon => m_Wrapper.m_Adventurer_SwitchWeapon;
        public InputActionMap Get() { return m_Wrapper.m_Adventurer; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AdventurerActions set) { return set.Get(); }
        public void SetCallbacks(IAdventurerActions instance)
        {
            if (m_Wrapper.m_AdventurerActionsCallbackInterface != null)
            {
                Movement.started -= m_Wrapper.m_AdventurerActionsCallbackInterface.OnMovement;
                Movement.performed -= m_Wrapper.m_AdventurerActionsCallbackInterface.OnMovement;
                Movement.canceled -= m_Wrapper.m_AdventurerActionsCallbackInterface.OnMovement;
                Rotate.started -= m_Wrapper.m_AdventurerActionsCallbackInterface.OnRotate;
                Rotate.performed -= m_Wrapper.m_AdventurerActionsCallbackInterface.OnRotate;
                Rotate.canceled -= m_Wrapper.m_AdventurerActionsCallbackInterface.OnRotate;
                Attack.started -= m_Wrapper.m_AdventurerActionsCallbackInterface.OnAttack;
                Attack.performed -= m_Wrapper.m_AdventurerActionsCallbackInterface.OnAttack;
                Attack.canceled -= m_Wrapper.m_AdventurerActionsCallbackInterface.OnAttack;
                SwitchWeapon.started -= m_Wrapper.m_AdventurerActionsCallbackInterface.OnSwitchWeapon;
                SwitchWeapon.performed -= m_Wrapper.m_AdventurerActionsCallbackInterface.OnSwitchWeapon;
                SwitchWeapon.canceled -= m_Wrapper.m_AdventurerActionsCallbackInterface.OnSwitchWeapon;
            }
            m_Wrapper.m_AdventurerActionsCallbackInterface = instance;
            if (instance != null)
            {
                Movement.started += instance.OnMovement;
                Movement.performed += instance.OnMovement;
                Movement.canceled += instance.OnMovement;
                Rotate.started += instance.OnRotate;
                Rotate.performed += instance.OnRotate;
                Rotate.canceled += instance.OnRotate;
                Attack.started += instance.OnAttack;
                Attack.performed += instance.OnAttack;
                Attack.canceled += instance.OnAttack;
                SwitchWeapon.started += instance.OnSwitchWeapon;
                SwitchWeapon.performed += instance.OnSwitchWeapon;
                SwitchWeapon.canceled += instance.OnSwitchWeapon;
            }
        }
    }
    public AdventurerActions @Adventurer => new AdventurerActions(this);
    public interface IInKeeperActions
    {
        void OnMovement(InputAction.CallbackContext context);
    }
    public interface IAdventurerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnSwitchWeapon(InputAction.CallbackContext context);
    }
}
