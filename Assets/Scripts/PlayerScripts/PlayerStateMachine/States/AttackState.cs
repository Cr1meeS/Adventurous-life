using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : PlayerState
{
    public AttackState(Player player, StateMachine stateMachine, PlayerStateFabric stateFabric) : base(player, stateMachine, stateFabric)
    {
    }

    public override void Enter()
    {
        Debug.Log("Enter HitState");
    }

    public override void HandleInput(string inputType)
    {
        base.HandleInput(inputType);
    }

    public override void Update()
    {
        
    }

    public override void Exit()
    {
        Debug.Log("Exit HitState");
    }
}
