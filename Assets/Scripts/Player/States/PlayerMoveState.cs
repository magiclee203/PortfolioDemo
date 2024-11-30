using Animancer;
using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    [SerializeField, Required] private ClipTransition _animation;
    [SerializeField, Required] private float _rotateSpeed = 10.0f;

    private void OnEnable()
    {
        Debug.Log("Move Layer Enter Move State");
        Player.Instance.Animancer.Play(_animation);
    }

    private void OnDisable()
    {
        Debug.Log("Move Layer Exit Move State");
    }

    private void Update()
    {
        Look();
    }

    private void OnAnimatorMove()
    {
        Move();
    }

    private void Look()
    {
        var inputVector = Player.Instance.InputValue.MoveVector;
        var targetDir = Quaternion.LookRotation(new Vector3(inputVector.x, 0.0f, inputVector.y));

        var currentRot = Player.Instance.Rb.rotation;
        var targetRot = Quaternion.Slerp(currentRot, targetDir, _rotateSpeed * Time.deltaTime);
        Player.Instance.Rb.MoveRotation(targetRot);
    }

    private void Move()
    {
        var currentPos = Player.Instance.Rb.position;
        var offset = Player.Instance.Animancer.Animator.deltaPosition;
        Player.Instance.Rb.MovePosition(currentPos + offset);
    }
}