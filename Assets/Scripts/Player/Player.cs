using Animancer;
using Sirenix.OdinInspector;
using UnityEngine;

public class Player : Singleton<Player>
{
    [SerializeField, Required]
    [BoxGroup("Animation")]
    private AnimancerComponent _animancer;

    [SerializeField, Required]
    [BoxGroup("Animation")]
    private AvatarMask _avatarMask;

    [SerializeField, Required]
    [BoxGroup("Events Subscribed"), LabelText("input value changed")]
    private SOPlayerInputValueChangedEvent _inputValueChangedEvent;

    [SerializeField, ReadOnly]
    [BoxGroup("Debug")]
    private PlayerInputValue _inputValue;

    private Rigidbody _rb;
    private AnimancerLayer _moveLayer;
    private AnimancerLayer _actionLayer;

    public AnimancerComponent Animancer => _animancer;
    public PlayerInputValue InputValue => _inputValue;
    public Rigidbody Rb => _rb;
    public AnimancerLayer MoveLayer => _moveLayer;
    public AnimancerLayer ActionLayer => _actionLayer;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();

        _moveLayer = _animancer.Layers[0];
        _actionLayer = _animancer.Layers[1];
        _actionLayer.Mask = _avatarMask;
        _actionLayer.ApplyAnimatorIK = true;
    }

    private void OnEnable()
    {
        _inputValueChangedEvent.Subscribe(OnPlayerInputValueChanged);
    }

    private void OnDisable()
    {
        _inputValueChangedEvent.Unsubscribe(OnPlayerInputValueChanged);
    }

    private void OnPlayerInputValueChanged(PlayerInputValue newValue)
    {
        _inputValue = newValue;
    }
}