using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    private void OnEnable()
    {
        // Debug.Log("Enter Idle State");
        Player.Instance.MoveLayer.Play(_animation);
    }

    private void OnDisable()
    {
        // Debug.Log("Exit Idle State");
    }
}