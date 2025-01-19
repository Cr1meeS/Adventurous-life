using UnityEngine;

public class IdleState : PlayerState
{
    private Vector2 _moveDirection;

    public IdleState(Player player, StateMachine stateMachine, PlayerStateFabric stateFabric) : base(player, stateMachine, stateFabric)
    {
    }

    public override void Enter()
    {
        Debug.Log("Enter IdleState");
        _animationController.SetAnimationBool("IsIdle", true);
    }

    public override void HandleInput(string inputType)
    {
        switch (inputType)
        {
            case "Jump":
                _stateMachine.StatesSteckPush(_stateFabric.JumpState);
                _animationController.SetAnimationBool("IsIdle", false);
                break;
            case "Mouse Left Button":
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
            _stateMachine.StatesSteckPush(_stateFabric.WalkState);
            _animationController.SetAnimationBool("IsIdle", false);
        }
    }

    public override void Exit()
    {
        Debug.Log("Exit IdleState");
        _animationController.SetAnimationBool("IsIdle", false);
    }
}
