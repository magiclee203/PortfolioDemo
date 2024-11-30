using System;
using Animancer;
using Sirenix.OdinInspector;
using UnityEngine;

public class Player : Singleton<Player>
{
    [SerializeField, Required] private AnimancerComponent _animancer;

    [SerializeField, Required]
    [BoxGroup("Events"), TitleGroup("Events/Subscribe")]
    private SOPlayerInputValueChanged _inputValueChanged;

    [SerializeField, ReadOnly]
    [BoxGroup("Debug")]
    private PlayerInputValue _inputValue;

    private Rigidbody _rb;

    public AnimancerComponent Animancer => _animancer;
    public PlayerInputValue InputValue => _inputValue;
    public Rigidbody Rb => _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _inputValueChanged.Subscribe(OnPlayerInputValueChanged);
    }

    private void OnDisable()
    {
        _inputValueChanged.Unsubscribe(OnPlayerInputValueChanged);
    }

    private void OnPlayerInputValueChanged(PlayerInputValue newValue)
    {
        _inputValue = newValue;
    }
}