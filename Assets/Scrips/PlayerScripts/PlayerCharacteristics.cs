using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacteristics : MonoBehaviour
{
    [SerializeField] private float _currentHealth, _maxHealth;
    [SerializeField] Player _player;

    public delegate void PlayerCurrentHealthChange(float health);
    public event PlayerCurrentHealthChange OnPlayerCurrentHealthChange;

    public delegate void CharacteristicsOnLoadSetted(PlayerCharacteristics playerCharacteristics);
    public event CharacteristicsOnLoadSetted OnCharacteristicsOnLoadSetted;

    [SerializeField, HideInInspector]
    public float CurrentHealth, MaxHealth;

    private void Start()
    {
        _player = GetComponent<Player>();
        SetCharacteristicsOnLoad();

        _player.OnPlayerGetDamage += TakeDamage;
    }

    private void SetCharacteristicsOnLoad()
    {
        CurrentHealth = _currentHealth;
        MaxHealth = _maxHealth;

        OnCharacteristicsOnLoadSetted?.Invoke(this);
    }

    private void TakeDamage(float damage)
    {
        if (_currentHealth > damage)
        {
            _currentHealth = _currentHealth - damage;
            OnPlayerCurrentHealthChange?.Invoke(_currentHealth);
        }
        else 
        {
            _player.KillEntity();
            OnPlayerCurrentHealthChange?.Invoke(0);
        }
    }
}
