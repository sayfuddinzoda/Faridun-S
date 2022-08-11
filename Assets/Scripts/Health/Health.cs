using System;
using UnityEngine;

public class Health : MonoBehaviour, ITakeDamage
{

    public Action<float> OnHealthChanged;
    public Action OnDie;

    [SerializeField] private float _currentHealth;
    [SerializeField, Min(0)] private float _maxHealth;
    [SerializeField] private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        if (damage <= 0 || _currentHealth <= 0)
            return;
        _currentHealth -= damage;
        OnHealthChanged?.Invoke(_currentHealth / _maxHealth);
        if (_currentHealth <= 0)
            Die();
    }

    private void Die() 
    {
        OnDie.Invoke();
        _animator.enabled = false;
    }

}
