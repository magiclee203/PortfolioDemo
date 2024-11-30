using Animancer;
using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerMoveIdleState : PlayerBaseState
{
    [SerializeField, Required] private ClipTransition _animation;

    private void OnEnable()
    {
        Debug.Log("Move Layer Enter Idle State");
        Player.Instance.Animancer.Play(_animation);
    }

    private void OnDisable()
    {
        Debug.Log("Move Layer Exit Idle State");
    }
}