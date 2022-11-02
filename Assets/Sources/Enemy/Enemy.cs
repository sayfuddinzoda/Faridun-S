using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{

    [SerializeField] private float _destroyTime;

    private Animator _animator;
    private Health _health;
    private CapsuleCollider _collider;

    private void Awake()
    {
        _collider = GetComponent<CapsuleCollider>();
        _animator = GetComponent<Animator>();
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _health.OnDie += Die;
    }

    private void OnDisable()
    {
        _health.OnDie -= Die;
    }

    private void Die() 
    {
        _collider.enabled = false;
        _animator.enabled = false;
        Destroy(gameObject, _destroyTime);
    }

}
