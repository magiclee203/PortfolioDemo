using Animancer;
using Animancer.FSM;
using Sirenix.OdinInspector;
using UnityEngine;

public abstract class PlayerBaseState : StateBehaviour
{
    protected virtual bool HideAnimationInInspector => false;

    [SerializeField, Required, HideIf("HideAnimationInInspector")]
    [BoxGroup("Animations")]
    protected TransitionAsset _animation;
}