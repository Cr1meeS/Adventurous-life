using UnityEngine;

public abstract class PlayerMovementState : PlayerState
{
    private Rigidbody _rigidbody;
    private Transform _camera;
    public PlayerMovementState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {
        _rigidbody = player.GetComponent<Rigidbody>();
        _camera = player.Camera;
    }


    protected void Move(Vector3 currentMoveDirection, Transform camera, Rigidbody rigidbody, float speed)
    {
        rigidbody.MovePosition(rigidbody.position + speed * Time.deltaTime * currentMoveDirection);
    }
}