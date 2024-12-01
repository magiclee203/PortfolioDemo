using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerChargeState : PlayerBaseState
{
    [SerializeField, Required]
    [BoxGroup("Events Published"), LabelText("charge end")]
    private SOEvent _chargeEndEvent;

    private void OnEnable()
    {
        Debug.Log("Enter Charge State");

        var state = Player.Instance.ActionLayer.Play(_animation);
        state.Events(this).OnEnd ??= () => { _chargeEndEvent.Notify(); };
    }

    private void OnDisable()
    {
        Player.Instance.ActionLayer.StartFade(0.0f);
    }
}