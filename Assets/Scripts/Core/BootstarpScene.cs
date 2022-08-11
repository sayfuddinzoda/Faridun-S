using UnityEngine;
using UnityEngine.UI;

public class BootstarpScene : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private PlayerSetup _player;
    [SerializeField] private PointsNavigator _navigator;
    [SerializeField] private Button _buttonStart;
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private LevelLoader _levelLoader;

    private void Awake()
    {
        Enter();
    }

    private void Enter() 
    {
        PlayerSetup playerSetup = Instantiate(_player, _startPoint.position, Quaternion.identity);
        playerSetup.MovementSetup(_navigator, _buttonStart, _levelLoader);
        playerSetup.GunSetup(_bulletPool);
    }

}
