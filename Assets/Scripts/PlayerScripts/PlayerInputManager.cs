public class PlayerInputManager 
{
    private Player _player;

    public InputActions InputActions;

    public delegate void InputHandler(string inputType);

    public event InputHandler OnJumpInput;
    public event InputHandler OnSprintInput;
    public event InputHandler OnMouseLeftButtonInput;
    public event InputHandler OnMouseRightButtonInput;

    public PlayerInputManager(Player player)
    {
        InputActions = new InputActions();
        _player = player;

        InputActions.PlayerControl.Jump.started += ctx => OnJump();
        InputActions.PlayerControl.Sprint.started += ctx => OnSpintStart();
        InputActions.PlayerControl.Sprint.canceled += ctx => OnSpintEnd();
        InputActions.PlayerControl.MouseLeftButton.performed += ctx => OnMouseLeftButton();
        InputActions.PlayerControl.MouseRightButton.performed += ctx => OnMouseRightButton();
    }

    public void Enable()
    {
        InputActions.Enable();
    }

    public void Disable()
    {
        InputActions.Disable();
    }

    private void OnJump()
    {
        OnJumpInput?.Invoke("Jump");
    }
    private void OnSpintStart()
    {
        OnSprintInput?.Invoke("Sprint Start");
    
    }
    private void OnSpintEnd()
    {
        OnSprintInput?.Invoke("Sprint End");

    }

    private void OnMouseLeftButton()
    {
        OnMouseLeftButtonInput?.Invoke("Mouse Left Button");
    }

    private void OnMouseRightButton()
    {
        OnMouseRightButtonInput?.Invoke("Mouse Right Button");
    }
}
