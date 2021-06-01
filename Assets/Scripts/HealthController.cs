using UnityEngine;
using System;

public class HealthController : MonoBehaviour
{
    [SerializeField] private float MaxHealth;

    public event Action OnDie = delegate { };
    public event Action OnHit = delegate { };

    private float _currentHealth;

    public float CurrentHealth
    {
        get
        {
            return _currentHealth;
        }
    }

    private void Start() => _currentHealth = MaxHealth;

    private void TakeDamage(float damage)
    {
        OnHit();
        _currentHealth -= damage;

        if(_currentHealth <= 0)
        {
            _currentHealth = 0;
            OnDie();
        }
    }
}
