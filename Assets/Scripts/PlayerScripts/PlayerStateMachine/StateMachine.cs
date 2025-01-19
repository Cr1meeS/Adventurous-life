using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private Player _player;
    private PlayerInputManager _playerInputManager;
    private PlayerStateFabric _stateFabric;

    private List<PlayerState> _statesSteck = new List<PlayerState>();
    private List<PlayerState> _statesSubSteck = new List<PlayerState>();
    private List<PlayerState> _attackStatesSteck = new List<PlayerState>();

    //main steck
    public void StatesSteckPush(PlayerState state)
    {
        _statesSteck.Add(state);
        state.Enter();
    }
    public void StatesSteckPop(PlayerState state)
    {
        state.Exit();
        _statesSteck.Remove(state);
        _statesSteck[_statesSteck.Count - 1].Enter();
    }
    public void StatesSteckClearPop(PlayerState state)
    {
        state.Exit();
        _statesSteck.Remove(state);
    }

    //sub steck
    public void StatesSubSteckPush(PlayerState state)
    {
        _statesSubSteck.Add(state);
        state.Enter();
    }
    public void StatesSubSteckPop(PlayerState state)
    {
        state.Exit();
        _statesSubSteck.Remove(state);
        _statesSubSteck[_statesSubSteck.Count - 1].Enter();
    }
    public void StatesSubSteckClearPop(PlayerState state)
    {
        state.Exit();
        _statesSubSteck.Remove(state);
    }

    //Attack steck
    public void AttackStatesSteckPush(PlayerState state)
    {
        _attackStatesSteck.Add(state);
        state.Enter();
    }
    public void AttackStatesSteckPop(PlayerState state)
    {
        state.Exit();
        _attackStatesSteck.Remove(state);
        _attackStatesSteck[_attackStatesSteck.Count - 1].Enter();
    }
    public void AttackStatesSteckClearPop(PlayerState state)
    {
        state.Exit();
        _attackStatesSteck.Remove(state);
    }

    private void HandleInput(string inputType)
    {
        _statesSteck[_statesSteck.Count - 1].HandleInput(inputType);
        _statesSubSteck[_statesSubSteck.Count - 1].HandleInput(inputType);
    }

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        _playerInputManager = _player.PlayerInputManager;
        _playerInputManager.OnJumpInput += HandleInput;
        _playerInputManager.OnSprintInput += HandleInput;

        _stateFabric = new PlayerStateFabric(_player, this);

        StatesSteckPush(_stateFabric.IdleState);
        StatesSubSteckPush(_stateFabric.EmptyState);
       // AttackStatesSteckPush(_stateFabric.IdleState);
    }

    private void Update()
    {
       _statesSteck[_statesSteck.Count - 1].Update();
       _statesSubSteck[_statesSubSteck.Count - 1].Update();
       // _attackStatesSteck[_attackStatesSteck.Count - 1].Update();
    }

}
