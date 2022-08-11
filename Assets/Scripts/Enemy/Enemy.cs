using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{

    [SerializeField] private Animator _animator;
    [SerializeField] private Health _health;
    [SerializeField] private CapsuleCollider _collider;
    [SerializeField] private float _destroyTime;

    private void Awake()
    {
        _collider = GetComponent<CapsuleCollider>();
        _animator = GetComponent<Animator>();
        _health = GetComponent<Health>();
        _health.OnDie += Die;
    }

    private void Die() 
    {
        _collider.enabled = false;
        _animator.enabled = false;
        Destroy(gameObject, _destroyTime);
    }

}
