using UnityEngine;

public class PlayerInputManager 
{
    private Player _player;

    private InputActions _inputActions;

    public PlayerInputManager(Player player)
    {
        _inputActions = new InputActions();
        _player = player;

        _inputActions.PlayerControl.Jump.performed += ctx => OnJump();
        _inputActions.PlayerControl.Sprint.started += ctx => OnSpint();
        _inputActions.PlayerControl.Sprint.canceled += ctx => OnSpint();
    }


    public void Enable()
    {
        _inputActions.Enable();
    }

    public void Disable()
    {
        _inputActions.Disable();
    }

    private void OnJump()
    {
        Debug.Log("Jump");
        _player.Jump();
    }
    private void OnSpint()
    {

    _player.Sprint();
    }
}
