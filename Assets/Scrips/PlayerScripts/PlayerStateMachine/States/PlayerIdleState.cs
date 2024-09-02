using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine) { }

    public override void Enter()
    {
        _playerAnimationController.SetAnimationBool("IsIdle", true);
        Debug.Log("Enter IdleState");
    }

    public override void Exit()
    {
        _playerAnimationController.SetAnimationBool("IsIdle", false);
        Debug.Log("Exit IdleState");
    }

    public override void Update()
    {
        
    }
}
