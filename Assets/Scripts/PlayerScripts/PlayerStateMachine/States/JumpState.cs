using UnityEngine;

public class JumpState : PlayerState
{
    private PlayerJumping _playerJumping;
    private PlayerMoving _playerMoving;
    private PlayerRotating _playerRotating;

    private Vector2 _moveDirection;

    private bool _isJumping;

    public JumpState(Player player, StateMachine stateMachine, PlayerStateFabric stateFabric) : base(player, stateMachine, stateFabric)
    {
        _playerJumping = _player.PlayerJumping;
        _playerMoving = new PlayerMoving();
        _playerRotating = new PlayerRotating();

        _isJumping = false;
    }

    public override void Enter()
    {
        _playerJumping.OnLanded += OnPlayerLanded;
        Debug.Log("Enter JumpState");
        _animationController.SetAnimationBool("IsJumping", true);
        Jump();
    }

    public override void HandleInput(string inputType)
    {
        switch (inputType)
        {
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
    }

    public override void Exit()
    {
        Debug.Log("Exit JumpState");
        _animationController.SetAnimationBool("IsJumping", false);
        _playerJumping.OnLanded -= OnPlayerLanded;

    }

    private void Jump()
    {
        if (_isJumping == false)
        {
            _playerJumping.Jump(_player.MovementCharacteristics.JumpDuraction, _player.Rigidbody, _player.MovementCharacteristics.JumpHeight, _player.MovementCharacteristics.yJumpAnimation);
        }
        _isJumping = true;
    }

    private void OnPlayerLanded()
    {
        _isJumping = false;
        _stateMachine.StatesSteckPop(_stateFabric.JumpState);
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
