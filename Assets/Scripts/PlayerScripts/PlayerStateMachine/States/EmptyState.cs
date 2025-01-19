using UnityEngine;

public class EmptyState : PlayerState
{
    public EmptyState(Player player, StateMachine stateMachine, PlayerStateFabric stateFabric) : base(player, stateMachine, stateFabric)
    {
    }

    public override void Enter()
    {
        Debug.Log("Enter EmptyState");
    }

    public override void HandleInput(string inputType)
    {
        switch (inputType)
        {
            case "Sprint Start":
                _stateMachine.StatesSubSteckPush(_stateFabric.SprintState);
                break;
            default: break;
        }
    }

    public override void Update() { }

    public override void Exit()
    {
        Debug.Log("Exit EmptyState");
    }
}
