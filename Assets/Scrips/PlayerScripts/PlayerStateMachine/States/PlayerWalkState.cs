using UnityEngine;

public class PlayerWalkState : PlayerState
{
    public PlayerWalkState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine) { }

    public override void Enter()
    {
        _playerAnimationController.SetAnimationBool("IsWalking", true);
        Debug.Log("Enter WalkState");
    }

    public override void Exit()
    {
        _playerAnimationController.SetAnimationBool("IsWalking", false);
        Debug.Log("False WalkState");
    }

    public override void Update()
    {
        base.Update();
    }
}
