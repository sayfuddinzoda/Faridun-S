using UnityEngine;

public class BulletPool : MonoBehaviour
{

    public PoolMono<Bullet> _pool;

    [SerializeField] private int _count;
    [SerializeField] private bool _autoExpand = false;
    [SerializeField] private Bullet _bullet;


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
