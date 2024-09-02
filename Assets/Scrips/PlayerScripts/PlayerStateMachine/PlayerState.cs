using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class PlayerState
{
    protected Player _player;
    protected PlayerStateMachine _playerStateMachine;
    protected PlayerAnimationController _playerAnimationController;

    public PlayerState(Player player, PlayerStateMachine playerStateMachine)
    {
        _player = player;
        _playerStateMachine = playerStateMachine;
        _playerAnimationController = new PlayerAnimationController(_player.GetComponent<Animator>());
    }

    public virtual void Enter() { }

    public virtual void Update() { }

    public virtual void Exit() { }
}
