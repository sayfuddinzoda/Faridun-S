using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public sealed class Ragdoll : MonoBehaviour
{

    [SerializeField] private List<Rigidbody> _parts;
    [SerializeField] [Range(0,10)] private float _shoveRandomForceMin;
    [SerializeField] [Range(0,10)] private float _shoveRandomForceMax;
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
        Disable();
    }

    private void OnEnable()
    {
        _health.OnDie += Enable;
    }

    private void OnDisable()
    {
        _health.OnDie -= Enable;
    }

    private void Enable()
    {
        _parts.ForEach((part) => { part.isKinematic = false; });
        ShoveBody();
    }

    private void Disable()
    {
        _parts.ForEach((part) => { part.isKinematic = true; });
    }

    private void ShoveBody() 
    {
        _parts.ForEach((part) =>
        {
            Vector3 randomDirection = GetRandomForceDirection();
            part.AddForce(randomDirection, ForceMode.Impulse);
        });
    }

    private Vector3 GetRandomForceDirection() 
    {

     return new Vector3(
                GetRandomForce(),
                GetRandomForce(),
                GetRandomForce());
    }

    private float GetRandomForce() 
    {
        return Random.Range(-_shoveRandomForceMin, _shoveRandomForceMax);
    }

}
