using UnityEngine;
using UnityEngine.Events;

public sealed class Point : MonoBehaviour
{

    public event UnityAction OnComplete;

    [SerializeField] private Spawner[] _spawners;
    [SerializeField] private int _activeSpawnersCount;
    [SerializeField] private float _sphereRadius = 1;
    [SerializeField] private bool _complete;
    public bool Complete => _complete;

    private void Awake()
    {
        _spawners = GetComponentsInChildren<Spawner>();
        _activeSpawnersCount = _spawners.Length;

        if (SpawnersIsNotEmpty())
            Spawn();
        else
            _complete = true;
    }

    private void Spawn() 
    {
        for (int i = 0; i < _spawners.Length; i++)
        {
            _spawners[i].Spawn();
            _spawners[i].OnEnemiesDie += RemoveSpawner;
        }
    }

    private void OnDrawGizmos()
    {
        Spawner[] spawners = GetComponentsInChildren<Spawner>();

        if (spawners.Length == 0)
            return;

        Gizmos.color = Color.red;

        foreach(Spawner spawner in spawners) 
        {
            Gizmos.DrawLine(transform.position, spawner.transform.position);
        }
    }

    private void RemoveSpawner() 
    {
        _activeSpawnersCount--;

        if (_activeSpawnersCount <= 0)
        {
            OnComplete?.Invoke();
            _complete = true;
        }
    }

    private bool SpawnersIsNotEmpty()
    {
        return _spawners.Length != 0;
    } 

}
