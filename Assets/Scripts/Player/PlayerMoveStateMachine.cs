using Animancer.FSM;
using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerMoveStateMachine : MonoBehaviour
{
    [SerializeField, Required] private StateMachine<PlayerBaseState>.WithDefault _stateMachine;
    [SerializeField, Required] private PlayerBaseState _idleState;
    [SerializeField, Required] private PlayerBaseState _moveState;

    private void Awake()
    {
        _stateMachine.InitializeAfterDeserialize();
    }

    private void Update()
    {
        _stateMachine.TrySetState(Player.Instance.InputValue.MoveVector == Vector2.zero ? _idleState : _moveState);
    }
}