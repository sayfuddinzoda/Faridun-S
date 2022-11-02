using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerSetup : MonoBehaviour
{

    [SerializeField] private Gun _gun;

    private PlayerMovement _movement;

    private void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
    }

    public void MovementSetup(PointsNavigator navigator, Level level) 
    {
        _movement.Consturctor(navigator, level);
    }

    public void GunSetup(BulletPool bulletPool) 
    {
        _gun.Constructor(bulletPool);
    }

}
