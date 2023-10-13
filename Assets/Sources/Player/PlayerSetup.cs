using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public sealed class PlayerSetup : MonoBehaviour
{

    private PlayerMovement _movement;

    [field: SerializeField] public Gun Gun { get; private set; }
    
    private void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
    }

    public void MovementSetup(PointsNavigator navigator, Level level) 
    {
        _movement.Constructor(navigator, level);
    }

    public void GunSetup(BulletPool bulletPool) 
    {
        Gun.Constructor(bulletPool);
    }

}
