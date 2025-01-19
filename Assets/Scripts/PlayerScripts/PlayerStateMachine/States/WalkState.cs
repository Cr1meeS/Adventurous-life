using UnityEngine;

public class WalkState : PlayerState
{
    private Vector2 _moveDirection;
    private PlayerMoving _playerMoving;
    private PlayerRotating _playerRotating;

    public WalkState(Player player, StateMachine stateMachine, PlayerStateFabric stateFabric) : base(player, stateMachine, stateFabric)
    {
        _playerMoving = new PlayerMoving();
        _playerRotating = new PlayerRotating();
    }

    public override void Enter()
    {
        Debug.Log("Enter WalkState");
        _animationController.SetAnimationBool("IsWalking", true);
    }

    public override void HandleInput(string inputType)
    {
        switch (inputType)
        {
            case "Jump":
                _stateMachine.StatesSteckPush(_stateFabric.JumpState);
                break;
            default: break;
        }
    }

    public override void Update()
    {
        _moveDirection = _player.PlayerInputManager.InputActions.PlayerControl.Move.ReadValue<Vector2>();
        if (_moveDirection != Vector2.zero)
        {
            Move(_moveDirection);
            Rotate(_moveDirection);
        }
        else 
        {
            _stateMachine.StatesSteckPop(_stateFabric.WalkState);
        }
    }

    public override void Exit()
    {
        Debug.Log("Exit WalkState");
        _animationController.SetAnimationBool("IsWalking", false);
    }

    private void Move(Vector2 moveDirection)
    {
        _playerMoving.Move(moveDirection, _player.Camera.transform, _player.Rigidbody, _player.MovementCharacteristics.Speed);
    }

    private void Rotate(Vector2 moveDirection)
    {
        _playerRotating.Rotate(moveDirection, _player.Camera.transform, _player.transform, _player.MovementCharacteristics.RotateSpeed);
    }
}
