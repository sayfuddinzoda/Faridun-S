using UnityEngine;

public class EnemySingleSpawner : Spawner
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Enemy _enemySpawn;
    [SerializeField] private Transform _lookAtPosition;
    [SerializeField] private Transform _parent;

    public override void Spawn() 
    {
        Enemy enemy = Instantiate(_enemy, transform.position, Quaternion.identity, _parent);
        if(_lookAtPosition)
            enemy.transform.LookAt(_lookAtPosition);
        UpdateEnemy(enemy);
    }

    private void UpdateEnemy(Enemy enemy) 
    {
        _enemySpawn = enemy;
        _enemySpawn.GetComponent<Health>().OnDie += EnemyDie;
    }

    private void EnemyDie() 
    {
        OnEnemiesDie?.Invoke();
    }
}
