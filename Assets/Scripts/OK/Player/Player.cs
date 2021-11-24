using System;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable, IHealth
{
    [SerializeField] private int _maxHealth;
    private int _currentHealth;

    public event Action OnDie;
    public event Action<int, int> OnHealthChanged;
    
    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void ApplyDamage(int value)
    {
        _currentHealth -= value;
        OnHealthChanged?.Invoke(_currentHealth, _maxHealth);
        
        if (_currentHealth <= 0)
        {
            OnDie?.Invoke();
        }
    }
}