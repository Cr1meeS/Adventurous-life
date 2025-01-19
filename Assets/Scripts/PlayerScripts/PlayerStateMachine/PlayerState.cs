using UnityEngine;

public abstract class PlayerState
{
    protected Player _player;
    protected StateMachine _stateMachine;
    protected PlayerStateFabric _stateFabric;
    protected PlayerAnimationController _animationController;

    public PlayerState(Player player, StateMachine stateMachine, PlayerStateFabric stateFabric)
    {
        _player = player;
        _stateMachine = stateMachine;
        _stateFabric = stateFabric;
        _animationController = new PlayerAnimationController(_player.GetComponent<Animator>());
    }

    public virtual void Enter() { }

    public virtual void HandleInput(string inputType) { }

    public virtual void Update() { }

    public virtual void Exit() { }
}
