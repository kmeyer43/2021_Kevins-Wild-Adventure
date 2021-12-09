// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""Controls"",
            ""id"": ""e6a98396-0b50-4dfc-a35d-5a07171b804f"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""2ce808b4-0ebf-4e1e-86aa-b0abb1e1c883"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""122a8b5d-874a-4321-b86a-944045387b4d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9e4eb43f-5a46-4463-b994-8487e2b326aa"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Global Controls"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a3ac3472-06e6-4da6-8c12-a5d22b8cb966"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Global Controls"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""MoveKeyboard"",
                    ""id"": ""a9b80468-8aa5-4fd0-9760-10294400dfdb"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""226ac1c0-5cd0-405b-ad1d-704b32b0a3e8"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Global Controls"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""534ce017-e7fb-4244-b8a3-ce560226f969"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Global Controls"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""MoveController"",
                    ""id"": ""d614c738-f1a9-438a-a4d9-b6fdefe889bf"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""de91ab14-d9b7-433e-8f1b-4543b9f62462"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Global Controls"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""8dc11fe6-b45a-402b-98c0-2435190461d2"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Global Controls"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Global Controls"",
            ""bindingGroup"": ""Global Controls"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Controls
        m_Controls = asset.FindActionMap("Controls", throwIfNotFound: true);
        m_Controls_Jump = m_Controls.FindAction("Jump", throwIfNotFound: true);
        m_Controls_Movement = m_Controls.FindAction("Movement", throwIfNotFound: true);
    }

    public void Dispose()
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

    // Controls
    private readonly InputActionMap m_Controls;
    private IControlsActions m_ControlsActionsCallbackInterface;
    private readonly InputAction m_Controls_Jump;
    private readonly InputAction m_Controls_Movement;
    public struct ControlsActions
    {
        private @InputMaster m_Wrapper;
        public ControlsActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Controls_Jump;
        public InputAction @Movement => m_Wrapper.m_Controls_Movement;
        public InputActionMap Get() { return m_Wrapper.m_Controls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControlsActions set) { return set.Get(); }
        public void SetCallbacks(IControlsActions instance)
        {
            if (m_Wrapper.m_ControlsActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnJump;
                @Movement.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMovement;
            }
            m_Wrapper.m_ControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
            }
        }
    }
    public ControlsActions @Controls => new ControlsActions(this);
    private int m_GlobalControlsSchemeIndex = -1;
    public InputControlScheme GlobalControlsScheme
    {
        get
        {
            if (m_GlobalControlsSchemeIndex == -1) m_GlobalControlsSchemeIndex = asset.FindControlSchemeIndex("Global Controls");
            return asset.controlSchemes[m_GlobalControlsSchemeIndex];
        }
    }
    public interface IControlsActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
    }
}
