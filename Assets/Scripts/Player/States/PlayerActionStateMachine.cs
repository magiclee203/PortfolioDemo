using Animancer.FSM;
using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerActionStateMachine : MonoBehaviour
{
    [SerializeField, Required]
    [BoxGroup("States")]
    private PlayerBaseState _empty;

    [SerializeField, Required]
    [BoxGroup("States")]
    private PlayerBaseState _charge;

    [SerializeField, Required]
    [BoxGroup("States")]
    private PlayerBaseState _holdOn;

    [SerializeField, Required]
    [BoxGroup("States")]
    private PlayerBaseState _cast;

    [SerializeField, Required]
    [BoxGroup("Events Subscribed"), LabelText("charge end")]
    private SOEvent _chargeEndEvent;

    [SerializeField, Required]
    [BoxGroup("Events Subscribed"), LabelText("cast end")]
    private SOEvent _castEndEvent;

    private readonly StateMachine<PlayerBaseState>.WithDefault _stateMachine = new();

    private bool _isChargeAnimationEnd;
    private bool _isCastAnimationEnd;

    private void OnEnable()
    {
        _chargeEndEvent.Subscribe(OnChargeAnimationEnd);
        _castEndEvent.Subscribe(OnCastAnimationEnd);
    }

    private void OnDisable()
    {
        _chargeEndEvent.Unsubscribe(OnChargeAnimationEnd);
        _castEndEvent.Unsubscribe(OnCastAnimationEnd);
    }

    private void Start()
    {
        _stateMachine.DefaultState = _empty;
    }

    private void Update()
    {
        switch (_stateMachine.CurrentState)
        {
            case PlayerEmptyState:
                _isChargeAnimationEnd = false;
                _isCastAnimationEnd = false;

                if (Player.Instance.InputValue.IsUsingAbility)
                    _stateMachine.TrySetState(_charge);
                break;

            case PlayerChargeState:
                if (_isChargeAnimationEnd)
                    _stateMachine.TrySetState(_holdOn);
                else if (!Player.Instance.InputValue.IsUsingAbility)
                    _stateMachine.TrySetState(_empty);
                break;

            case PlayerHoldOnState:
                if (!Player.Instance.InputValue.IsUsingAbility)
                    _stateMachine.TrySetState(_cast);
                break;

            case PlayerCastState:
                if (_isCastAnimationEnd)
                    _stateMachine.ForceSetDefaultState();
                break;
        }
    }

    private void OnChargeAnimationEnd()
    {
        _isChargeAnimationEnd = true;
    }

    private void OnCastAnimationEnd()
    {
        _isCastAnimationEnd = true;
    }
}