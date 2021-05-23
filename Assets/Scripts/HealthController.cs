using UnityEngine;
using System;

public class HealthController : MonoBehaviour
{
    [SerializeField] private float MaxHealth;

    public event Action OnDie = delegate { };
    public event Action OnHit = delegate { };

    private float _currentHealth;

    private void Start() => _currentHealth = MaxHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<DamageDeal>();
        if(enemy != null)
        {
            TakeDamage(enemy.DamageToDeal);
        }
    }

    private void TakeDamage(float damage)
    {
        OnHit();
        _currentHealth -= damage;

        if(_currentHealth <= 0)
        {
            OnDie();
        }
    }
}
