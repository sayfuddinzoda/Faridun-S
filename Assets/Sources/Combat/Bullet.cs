using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public sealed class Bullet : MonoBehaviour
{

    [field: SerializeField, Min(0)] public float Damage { get; private set; }
    [field: SerializeField, Min(0)] public float Speed { get; private set; }

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Initialized(Vector3 targetPosition) 
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        _rigidbody.velocity = direction * Speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out ITakeDamage target))
        {
            target.TakeDamage(Damage);
        }

        gameObject.SetActive(false);
    }

}
