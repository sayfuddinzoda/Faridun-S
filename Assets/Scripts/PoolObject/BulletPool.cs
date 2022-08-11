using UnityEngine;
using System.Collections.Generic;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private int _count;
    [SerializeField] private bool _autoExpand = false;
    [SerializeField] private Bullet _bullet;

    public PoolMono<Bullet> _pool;

    private void Awake()
    {
        _pool = new PoolMono<Bullet>(_bullet, _count, transform);
        _pool.AudtoExpand = _autoExpand;
    }

    public Bullet GetFreeBullet(Transform position) 
    {
        return _pool.GetFreeElemnt(position);
    }
}
