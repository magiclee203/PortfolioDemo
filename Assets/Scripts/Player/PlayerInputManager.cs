using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    [SerializeField, Required]
    [BoxGroup("Events"), TitleGroup("Events/Publish")]
    private SOPlayerInputValueChanged _inputValueChanged;

    private PlayerInputAction _inputAction;
    private PlayerInputValue _inputValue = new();

    private void Awake()
    {
        _inputAction = new PlayerInputAction();
    }

    private void OnEnable()
    {
        _inputAction.Enable();
        Subscribe();
    }

    private void OnDisable()
    {
        _inputAction.Disable();
        Unsubscribe();
    }

    private void Subscribe()
    {
        _inputAction.Player.Move.performed += OnMoveVectorChanged;
        _inputAction.Player.Move.canceled += OnMoveVectorChanged;
        _inputAction.Player.Run.performed += OnIsRunningChanged;
        _inputAction.Player.Run.canceled += OnIsRunningChanged;
        _inputAction.Player.UseAbility.performed += OnIsUsingAbilityChanged;
        _inputAction.Player.UseAbility.canceled += OnIsUsingAbilityChanged;
    }

    private void Unsubscribe()
    {
        _inputAction.Player.Move.performed -= OnMoveVectorChanged;
        _inputAction.Player.Move.canceled -= OnMoveVectorChanged;
        _inputAction.Player.Run.performed -= OnIsRunningChanged;
        _inputAction.Player.Run.canceled -= OnIsRunningChanged;
        _inputAction.Player.UseAbility.performed -= OnIsUsingAbilityChanged;
        _inputAction.Player.UseAbility.canceled -= OnIsUsingAbilityChanged;
    }

    private void OnMoveVectorChanged(InputAction.CallbackContext context)
    {
        _inputValue.MoveVector = context.ReadValue<Vector2>();
        _inputValueChanged.Notify(_inputValue);
    }

    private void OnIsRunningChanged(InputAction.CallbackContext context)
    {
        _inputValue.IsRunning = context.ReadValueAsButton();
        _inputValueChanged.Notify(_inputValue);
    }

    private void OnIsUsingAbilityChanged(InputAction.CallbackContext context)
    {
        _inputValue.IsUsingAbility = context.ReadValueAsButton();
        _inputValueChanged.Notify(_inputValue);
    }
}

[Serializable]
public struct PlayerInputValue
{
    public Vector2 MoveVector;
    public bool IsRunning;
    public bool IsUsingAbility;
}