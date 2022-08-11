using UnityEngine;

public class EnemySingleSpawner : Spawner
{

    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Enemy _enemySpawn;
    [SerializeField] private Health _enemyHealth;
    [SerializeField] private Transform _lookAtPosition;
    [SerializeField] private Transform _parent;

    public override void Spawn() 
    {
        Enemy enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity, _parent);
        if(_lookAtPosition)
            enemy.transform.LookAt(_lookAtPosition);
        UpdateEnemy(enemy);
    }

    private void UpdateEnemy(Enemy enemy) 
    {
        _enemySpawn = enemy;
        _enemyHealth = _enemySpawn.GetComponent<Health>();
        _enemyHealth.OnDie += EnemyDie;
    }

    private void EnemyDie() 
    {
        OnEnemiesDie?.Invoke();
    }

}
