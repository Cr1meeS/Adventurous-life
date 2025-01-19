public class PlayerStateFabric
{
    public IdleState IdleState;
    public JumpState JumpState;
    public WalkState WalkState;
    public SprintState SprintState;
    public EmptyState EmptyState;
    public AttackState AttackState;

    public PlayerStateFabric(Player player, StateMachine stateMachine)
    {
        IdleState = new IdleState(player, stateMachine, this);
        JumpState = new JumpState(player, stateMachine, this);
        WalkState = new WalkState(player, stateMachine, this);
        SprintState = new SprintState(player, stateMachine, this);
        EmptyState = new EmptyState(player, stateMachine, this);
        AttackState = new AttackState(player, stateMachine, this);
    }
}
