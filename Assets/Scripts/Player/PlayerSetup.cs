using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerSetup : MonoBehaviour
{
    [SerializeField] private Gun _gun;
    [SerializeField] private PlayerMovement _movement;

    private void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
    }

    public void MovementSetup(PointsNavigator navigator, Button buttonStart, LevelLoader levelLoader) 
    {
        _movement.Consturctor(navigator, buttonStart, levelLoader);
    }

    public void GunSetup(BulletPool bulletPool) 
    {
        _gun.Constructor(bulletPool);
    }

}
