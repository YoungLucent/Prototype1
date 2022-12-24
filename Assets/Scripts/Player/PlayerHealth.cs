using System;
using UnityEngine;

public class PlayerHealth : Health
{
    [Header("Health Settings")]
    [SerializeField] private int _health;
   
    private int _currentHealth;

    public override event Action<float> HealthChanged;
    public event Action OnDefeat;

    private void Start()
    {
        _currentHealth = _health;
    }
    public override void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Death();
        }
        else
        {
            float currentHealthAsPercantage = (float)_currentHealth / _health;
            HealthChanged?.Invoke(currentHealthAsPercantage);
        }
    }
    public override void Death()
    {
        HealthChanged?.Invoke(0);
        SoundManager.instance.PlayerDeathSound();
        OnDefeat?.Invoke();
    }
}
