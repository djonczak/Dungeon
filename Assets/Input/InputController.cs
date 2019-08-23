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
                },
                {
                    ""name"": ""PickUpItem"",
                    ""type"": ""Button"",
                    ""id"": ""faaa03bb-d0c1-42ef-a07f-9d24aa9bf9f1"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Fill"",
                    ""type"": ""Button"",
                    ""id"": ""f8b663ff-3421-430f-8ed2-b36962358d4a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=3,pressPoint=0.19)""
                },
                {
                    ""name"": ""DropItem"",
                    ""type"": ""Button"",
                    ""id"": ""50f94e8e-b2bc-44ac-a996-6e9e4b0eb0a4"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""PutOnTable"",
                    ""type"": ""Button"",
                    ""id"": ""e15a38b5-bda6-48b6-8913-05f70bc6f1ea"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
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
                },
                {
                    ""name"": ""Move"",
                    ""id"": ""05ed42f2-a607-4801-a653-cae950c5bc1e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a632d1e8-340a-4a9b-b495-4e3511b80c3c"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f151b089-c422-41b1-9c1c-8f3007ed54a0"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""78b798d2-aa84-47c4-99f8-f31c98f0bd89"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""137ee7d0-15fa-4858-85f1-0da2792894a6"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""dc8aefdc-92e5-440f-98f7-6cfdaba77ef8"",
                    ""path"": ""<DualShockGamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PickUpItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""31fc574d-b591-4d05-a95d-6f507b6fa5ea"",
                    ""path"": ""<SwitchProControllerHID>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PickUpItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""14671cbe-8e75-48e8-95c5-0f0b14c455c2"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PickUpItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""56b05542-aa79-4473-9bc8-2e2324202a24"",
                    ""path"": ""<Keyboard>/#(E)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PickUpItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""579b0c98-48f6-4ad9-adf3-cedd0bb2d933"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7669f34a-1c0c-4ba3-83e4-8ab184a0fe74"",
                    ""path"": ""<DualShockGamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""94c3ced0-4173-47ee-846d-39c177b41d99"",
                    ""path"": ""<SwitchProControllerHID>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""65462929-d34d-4e85-89a5-7b39986df90d"",
                    ""path"": ""<Keyboard>/#(E)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8638a9dc-4de8-473c-9138-b9b44520dccb"",
                    ""path"": ""<DualShockGamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DropItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ef6738e3-ffee-479c-8829-436e0bacae4b"",
                    ""path"": ""<SwitchProControllerHID>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DropItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cfd41689-7ca5-4b9b-b998-638390f156f3"",
                    ""path"": ""<XInputController>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DropItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de45a851-a400-4a4e-a9e4-9259047e709e"",
                    ""path"": ""<Keyboard>/#(Q)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DropItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""efe655a2-abc7-470e-8814-9b36f0736b54"",
                    ""path"": ""<XInputController>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PutOnTable"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fa05bbc3-7eab-474d-8b71-deab368cae7e"",
                    ""path"": ""<SwitchProControllerHID>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PutOnTable"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""046cc1a5-1f1e-423a-a2b4-5f508044169b"",
                    ""path"": ""<DualShockGamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PutOnTable"",
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
                    ""processors"": """",
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
                    ""name"": ""Keyboad"",
                    ""id"": ""eabf5cd2-00c4-4a25-b6c3-842732a11aa8"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d5041dec-96b0-4334-b11f-53ef26af60c4"",
                    ""path"": ""<Keyboard>/#(W)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c45e1aba-6f17-4279-a05e-145c77aa200d"",
                    ""path"": ""<Keyboard>/#(S)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b761583e-f6cc-46c4-8241-363f9e42d6d1"",
                    ""path"": ""<Keyboard>/#(A)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3d00a6ae-edf3-4f47-bd6e-93a93d3430e7"",
                    ""path"": ""<Keyboard>/#(D)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
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
                    ""id"": ""21d75525-fcfc-445e-b3bb-b205b039f32e"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""CompensateRotation"",
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
                    ""id"": ""b2dc3e82-f316-4cac-b869-1e79e4e7e17c"",
                    ""path"": ""<Mouse>/leftButton"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""9a783ba5-e333-4008-820f-43a5a6b72ddd"",
                    ""path"": ""<Keyboard>/#(Q)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""a577ca42-b80b-4c8a-b7e7-a1c56d6292ca"",
            ""actions"": [
                {
                    ""name"": ""Submit"",
                    ""type"": ""Value"",
                    ""id"": ""def164a2-0ec8-4217-8b45-87bcf2c4c3b5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""086aba94-5b15-490d-b1b5-60ed724567e6"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""44c756bf-f9b0-45b8-afd1-9b430214e6f4"",
                    ""path"": ""<DualShockGamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9185fd3a-209b-4c8d-8005-758fe0c67848"",
                    ""path"": ""<SwitchProControllerHID>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Submit"",
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
        m_InKeeper_PickUpItem = m_InKeeper.GetAction("PickUpItem");
        m_InKeeper_Fill = m_InKeeper.GetAction("Fill");
        m_InKeeper_DropItem = m_InKeeper.GetAction("DropItem");
        m_InKeeper_PutOnTable = m_InKeeper.GetAction("PutOnTable");
        // Adventurer
        m_Adventurer = asset.GetActionMap("Adventurer");
        m_Adventurer_Movement = m_Adventurer.GetAction("Movement");
        m_Adventurer_Rotate = m_Adventurer.GetAction("Rotate");
        m_Adventurer_Attack = m_Adventurer.GetAction("Attack");
        m_Adventurer_SwitchWeapon = m_Adventurer.GetAction("SwitchWeapon");
        // UI
        m_UI = asset.GetActionMap("UI");
        m_UI_Submit = m_UI.GetAction("Submit");
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
    private readonly InputAction m_InKeeper_PickUpItem;
    private readonly InputAction m_InKeeper_Fill;
    private readonly InputAction m_InKeeper_DropItem;
    private readonly InputAction m_InKeeper_PutOnTable;
    public struct InKeeperActions
    {
        private InputController m_Wrapper;
        public InKeeperActions(InputController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_InKeeper_Movement;
        public InputAction @PickUpItem => m_Wrapper.m_InKeeper_PickUpItem;
        public InputAction @Fill => m_Wrapper.m_InKeeper_Fill;
        public InputAction @DropItem => m_Wrapper.m_InKeeper_DropItem;
        public InputAction @PutOnTable => m_Wrapper.m_InKeeper_PutOnTable;
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
                PickUpItem.started -= m_Wrapper.m_InKeeperActionsCallbackInterface.OnPickUpItem;
                PickUpItem.performed -= m_Wrapper.m_InKeeperActionsCallbackInterface.OnPickUpItem;
                PickUpItem.canceled -= m_Wrapper.m_InKeeperActionsCallbackInterface.OnPickUpItem;
                Fill.started -= m_Wrapper.m_InKeeperActionsCallbackInterface.OnFill;
                Fill.performed -= m_Wrapper.m_InKeeperActionsCallbackInterface.OnFill;
                Fill.canceled -= m_Wrapper.m_InKeeperActionsCallbackInterface.OnFill;
                DropItem.started -= m_Wrapper.m_InKeeperActionsCallbackInterface.OnDropItem;
                DropItem.performed -= m_Wrapper.m_InKeeperActionsCallbackInterface.OnDropItem;
                DropItem.canceled -= m_Wrapper.m_InKeeperActionsCallbackInterface.OnDropItem;
                PutOnTable.started -= m_Wrapper.m_InKeeperActionsCallbackInterface.OnPutOnTable;
                PutOnTable.performed -= m_Wrapper.m_InKeeperActionsCallbackInterface.OnPutOnTable;
                PutOnTable.canceled -= m_Wrapper.m_InKeeperActionsCallbackInterface.OnPutOnTable;
            }
            m_Wrapper.m_InKeeperActionsCallbackInterface = instance;
            if (instance != null)
            {
                Movement.started += instance.OnMovement;
                Movement.performed += instance.OnMovement;
                Movement.canceled += instance.OnMovement;
                PickUpItem.started += instance.OnPickUpItem;
                PickUpItem.performed += instance.OnPickUpItem;
                PickUpItem.canceled += instance.OnPickUpItem;
                Fill.started += instance.OnFill;
                Fill.performed += instance.OnFill;
                Fill.canceled += instance.OnFill;
                DropItem.started += instance.OnDropItem;
                DropItem.performed += instance.OnDropItem;
                DropItem.canceled += instance.OnDropItem;
                PutOnTable.started += instance.OnPutOnTable;
                PutOnTable.performed += instance.OnPutOnTable;
                PutOnTable.canceled += instance.OnPutOnTable;
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

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Submit;
    public struct UIActions
    {
        private InputController m_Wrapper;
        public UIActions(InputController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Submit => m_Wrapper.m_UI_Submit;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                Submit.started -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                Submit.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                Submit.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                Submit.started += instance.OnSubmit;
                Submit.performed += instance.OnSubmit;
                Submit.canceled += instance.OnSubmit;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    public interface IInKeeperActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnPickUpItem(InputAction.CallbackContext context);
        void OnFill(InputAction.CallbackContext context);
        void OnDropItem(InputAction.CallbackContext context);
        void OnPutOnTable(InputAction.CallbackContext context);
    }
    public interface IAdventurerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnSwitchWeapon(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnSubmit(InputAction.CallbackContext context);
    }
}
