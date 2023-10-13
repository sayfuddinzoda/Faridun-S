using UnityEngine;
using UnityEngine.Events;

public sealed class Health : MonoBehaviour, ITakeDamage
{

    public event UnityAction<float> OnHealthChanged;
    public event UnityAction OnDie;

    [field: SerializeField] public float CurrentHealth { get; private set; }
    [field: SerializeField, Min(0)] public float MaxHealth { get; private set; }
    
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        if (damage <= 0 || CurrentHealth <= 0)
            return;

        CurrentHealth -= damage;
        OnHealthChanged?.Invoke(CurrentHealth / MaxHealth);

        if (CurrentHealth <= 0)
            Die();
    }

    private void Die() 
    {
        OnDie.Invoke();
        _animator.enabled = false;
    }

}
