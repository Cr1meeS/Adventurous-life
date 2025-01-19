using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintState : PlayerState
{
    private bool _isSprinting;

    private Vector2 _moveDirection;

    public SprintState(Player player, StateMachine stateMachine, PlayerStateFabric stateFabric) : base(player, stateMachine, stateFabric)
    {
        _isSprinting = false;
    }

    public override void Enter()
    {
        Debug.Log("Enter SprintState");
        _animationController.SetAnimationBool("IsRunning", true);
        if (_isSprinting == false)
        {
            _player.MovementCharacteristics.Speed *= _player.MovementCharacteristics.Acceliration;
            _isSprinting = true;
        }
    }

    public override void HandleInput(string inputType)
    {
        switch (inputType)
        {
            case "Sprint End":
                _stateMachine.StatesSubSteckPop(_stateFabric.SprintState);
                break;
            default: break;
        }
    }

    public override void Update()
    {
        _moveDirection = _player.PlayerInputManager.InputActions.PlayerControl.Move.ReadValue<Vector2>();
        if (_moveDirection != Vector2.zero)
        {
            _animationController.SetAnimationBool("IsRunning", true);
        }
        else
        {
            _animationController.SetAnimationBool("IsRunning", false);
        }
    }

    public override void Exit()
    {
        Debug.Log("Exit SprintState");
        _animationController.SetAnimationBool("IsRunning", false);
        _player.MovementCharacteristics.Speed /= _player.MovementCharacteristics.Acceliration;
        _isSprinting = false;
    }
}
