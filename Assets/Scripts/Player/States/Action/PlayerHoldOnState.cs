using UnityEngine;

public class PlayerHoldOnState : PlayerBaseState
{
    private void OnEnable()
    {
        Debug.Log("Enter Hold On State");
        Player.Instance.ActionLayer.Play(_animation);
    }

    private void OnDisable()
    {
    }
}