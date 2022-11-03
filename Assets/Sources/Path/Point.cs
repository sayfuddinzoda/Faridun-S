using UnityEngine;
using UnityEngine.Events;

public class Point : MonoBehaviour
{

    public event UnityAction OnComplite;

    [SerializeField] private Spawner[] _spawners;
    [SerializeField] private int _activeSpawnersCount;
    [SerializeField] private float _sphereRadius = 1;
    [SerializeField] private bool _complite;
    public bool Complite => _complite;

    private void Awake()
    {
        _spawners = GetComponentsInChildren<Spawner>();
        _activeSpawnersCount = _spawners.Length;

        if (SpawnersIsNotEmpty())
            Spawn();
        else
            _complite = true;
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
            OnComplite?.Invoke();
            _complite = true;
        }
    }

    private bool SpawnersIsNotEmpty()
    {
        if (_spawners.Length == 0)
            return false;
        else
            return true;
    } 

}
