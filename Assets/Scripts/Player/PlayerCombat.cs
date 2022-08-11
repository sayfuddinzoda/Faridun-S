using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    [SerializeField] private Bullet _bullet;
    [SerializeField] private Gun _gun;
    [SerializeField] private LayerMask _ignoreLayerMask;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ~_ignoreLayerMask))
            {
                _gun.Shoot(hit.point);
            }
        }
        
    }

}
