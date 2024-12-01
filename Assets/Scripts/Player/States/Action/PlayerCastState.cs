using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerCastState : PlayerBaseState
{
    [SerializeField, Required]
    [BoxGroup("Events Published"), LabelText("cast end")]
    private SOEvent _castEndEvent;

    private void OnEnable()
    {
        Debug.Log("Enter Cast State");
        var state = Player.Instance.ActionLayer.Play(_animation);
        state.Events(this).OnEnd ??= () => { _castEndEvent.Notify(); };
    }

    private void OnDisable()
    {
        Player.Instance.ActionLayer.StartFade(0.0f);
    }
}