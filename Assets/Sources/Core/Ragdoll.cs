using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Ragdoll : MonoBehaviour
{

    [SerializeField] private List<Rigidbody> _parts;

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

    public void Enable()
    {
        _parts.ForEach((part) => { part.isKinematic = false; });
        ShoveBody();
    }

    public void Disable()
    {
        _parts.ForEach((part) => { part.isKinematic = true; });
    }

    private void ShoveBody() 
    {
        _parts.ForEach((part) =>
        {
            Vector3 randomDirection = new Vector3(Random.Range(0.1f, 3f), Random.Range(0.1f, 3f), Random.Range(0.1f, 3f));
            part.AddForce(randomDirection, ForceMode.Impulse);
        });
    }

}
