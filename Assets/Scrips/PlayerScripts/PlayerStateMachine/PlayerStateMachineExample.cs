using UnityEngine;

public class PlayerStateMachineExample : MonoBehaviour
{
    private PlayerStateMachine _playerStateMachine;
    private Player _player;

    private void Start()
    {
        _playerStateMachine = new PlayerStateMachine();
        _player = GetComponent<Player>();

        _playerStateMachine.Addstate(new PlayerIdleState(_player, _playerStateMachine));

        _playerStateMachine.Initialize(new PlayerIdleState(_player, _playerStateMachine));
    }

    private void Update()
    {
        _playerStateMachine.Update();
    }
}

