using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{

    [SerializeField] private float _cooldown = 0.25f;
    [SerializeField] private bool _canShoot = true;
    [SerializeField] private Transform _bulletSpawnPosition;
    [SerializeField] private BulletPool _bulletPool;

    public void Constructor(BulletPool bulletPool) 
    {
        _bulletPool = bulletPool;
    }
    public void Shoot(Vector3 target) 
    {
        if (!_canShoot)
            return;

        Bullet bullet = _bulletPool.GetFreeBullet(transform);
        bullet.Initialized(target);
        _canShoot = false;
        StartCoroutine(CooldownTick());
    }

    private IEnumerator CooldownTick() 
    {
        yield return new WaitForSeconds(_cooldown);
        _canShoot = true;
    }

}
