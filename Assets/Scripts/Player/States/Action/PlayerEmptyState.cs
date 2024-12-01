using UnityEngine;

/**
 * Do Nothing
 */
public class PlayerEmptyState : PlayerBaseState
{
    protected override bool HideAnimationInInspector => true;

    private void OnEnable()
    {
        Debug.Log("Enter Empty State");
    }
}