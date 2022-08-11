using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Ragdoll : MonoBehaviour
{

    [SerializeField] private List<Rigidbody> _parts;
    [SerializeField] private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _health.OnDie += Enable;
        Disable();
    }

    public void Enable()
    {
        _parts.ForEach((part) => { part.isKinematic = false; });
        _parts.ForEach((part) => 
        {
            Vector3 randomDirection = new Vector3(Random.Range(0.1f, 3f), Random.Range(0.1f, 3f), Random.Range(0.1f, 3f));
            part.AddForce(randomDirection,ForceMode.Impulse); 
        });
    }

    public void Disable()
    {
        _parts.ForEach((part) => { part.isKinematic = true; });
    }

}
