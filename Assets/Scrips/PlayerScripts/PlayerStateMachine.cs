using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine
{

    private Dictionary<Type, PlayerState> _states = new Dictionary<Type, PlayerState>();

    public PlayerState CurrentState { get; private set; }

    public void Initialize(PlayerState startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    public void Addstate(PlayerState state)
    {
        _states.Add(state.GetType(), state);
    }

    public void SwitchState<T>() where T : PlayerState
    {
        var type = typeof(T);

        if (CurrentState != null && CurrentState.GetType() == type)
        {
            return;
        }
        if (_states.TryGetValue(type, out var newState))
        {
            CurrentState?.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }
    }

    public void Update()
    {
        CurrentState.Update();
    }
}
