using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerHP : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerCharacteristics _playerCharacteristics;
    [SerializeField] private TextMeshProUGUI _currentHealth, _maxHealth;
    [SerializeField] private Slider _healthSlider;

    private void Awake()
    {
        _playerCharacteristics.OnPlayerCurrentHealthChange += ChangeCurrentHealth;
        _playerCharacteristics.OnCharacteristicsOnLoadSetted += SetHealthOnLoad;
    }

    private void SetHealthOnLoad(PlayerCharacteristics characteristics)
    {
        _currentHealth.text = characteristics.CurrentHealth.ToString();
        _maxHealth.text = characteristics.MaxHealth.ToString();
        _healthSlider.maxValue = characteristics.MaxHealth;
    }

    private void ChangeCurrentHealth(float amount)
    {
        _currentHealth.text = amount.ToString();
        _healthSlider.value = amount;
    }

    private void ChangeMaxHealth(float amount)
    {
        _maxHealth.text = amount.ToString();
    }
}
