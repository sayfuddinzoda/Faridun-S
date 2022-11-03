using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    [SerializeField] private PlayerMovement _player;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Gun _gun;
    [SerializeField] private LayerMask _ignoreLayerMask;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;    
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_player.MovementState == MovementState.move)
                return;

            RaycastHit hit;
            var ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ~_ignoreLayerMask))
            {
                _gun.Shoot(hit.point);
            }
        }
    }

}
