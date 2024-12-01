using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    [SerializeField, Required] private float _rotateSpeed = 10.0f;

    private void OnEnable()
    {
        // Debug.Log("Enter Move State");
        Player.Instance.MoveLayer.Play(_animation);
    }

    private void OnDisable()
    {
        // Debug.Log("Exit Move State");
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
        if (Player.Instance.InputValue.MoveVector == Vector2.zero) return;

        var inputVector = Player.Instance.InputValue.MoveVector;
        var targetDir = Quaternion.LookRotation(new Vector3(inputVector.x, 0.0f, inputVector.y).ToIsometric());

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