using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{

    [SerializeField, Min(0)] private float _damage;
    [SerializeField, Min(0)] private float _speed;
    [SerializeField] private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Initialized(Vector3 target) 
    {
        Vector3 direction = (target - transform.position).normalized;
        _rigidbody.velocity = direction * _speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out ITakeDamage target))
        {
            target.TakeDamage(_damage);
        }
        gameObject.SetActive(false);
    }

}
