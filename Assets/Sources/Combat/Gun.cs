using UnityEngine;
using System.Collections;

public sealed class Gun : MonoBehaviour
{

    [field: SerializeField] public float Cooldown { get; private set; } = 0.25f;
    
    private BulletPool _bulletPool;
    private bool _canShoot = true;
    
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
        yield return new WaitForSeconds(Cooldown);
        _canShoot = true;
    }

}
