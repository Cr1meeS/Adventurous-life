using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, IDamageable, IKillable
{
    [SerializeField] private PlayerMovement _playerMovement;

    private PlayerInputManager _playerInputManager;

    public delegate void _PlayerDead();
    public event _PlayerDead OnPlayerDead;

    public delegate void _playerGetDamage(float damage);
    public event _playerGetDamage OnPlayerGetDamage;

    public Transform Camera;

    private void Awake()
    {
        _playerInputManager = new PlayerInputManager(this);
    }



    private void OnEnable()
    {
        _playerInputManager.Enable();
    }
    private void OnDisable()
    {
        _playerInputManager.Disable();
    }

    public void ApplyDamage(float damage)
    {
        OnPlayerGetDamage?.Invoke(damage);
    }

    public void KillEntity()
    {
        OnPlayerDead?.Invoke();
    }


    //Movement methods
    public void Jump()
    {
        _playerMovement.CallJump();
    }

    public void Sprint()
    {
        _playerMovement.SprintCall();
    }



}
