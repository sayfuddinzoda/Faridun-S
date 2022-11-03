using UnityEngine;

public class BootstarpLevel : MonoBehaviour
{

    [SerializeField] private Transform _startPoint;
    [SerializeField] private PlayerSetup _player;
    [SerializeField] private PointsNavigator _navigator;
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private Level _level;

    private void Awake()
    {
        Enter();
    }

    private void Enter() 
    {
        PlayerSetup playerSetup = Instantiate(_player, _startPoint.position, Quaternion.identity);
        playerSetup.MovementSetup(_navigator, _level);
        playerSetup.GunSetup(_bulletPool);
    }

}
