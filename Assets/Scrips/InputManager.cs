using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private InputActions _inputActions;

        private void Awake()
    {
        _inputActions = new InputActions();
        _inputActions.SystemControl.CloseGame.performed += ctx => CloseGame();
    }

    private void CloseGame()
    {
        Application.Quit();
    }
}
