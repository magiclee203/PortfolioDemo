using System;
using Animancer.FSM;
using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerMoveStateMachine : MonoBehaviour
{
    [SerializeField, Required]
    [BoxGroup("States")]
    private PlayerBaseState _idle;

    [SerializeField, Required]
    [BoxGroup("States")]
    private PlayerBaseState _move;

    private readonly StateMachine<PlayerBaseState>.WithDefault _stateMachine = new();

    private void Start()
    {
        _stateMachine.DefaultState = _idle;
    }

    private void Update()
    {
        _stateMachine.TrySetState(Player.Instance.InputValue.MoveVector == Vector2.zero ? _idle : _move);
    }
}