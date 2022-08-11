using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMovement))]
public class PlayerAnimator : MonoBehaviour
{

    private Animator _animator;
    [SerializeField] private PlayerMovement _playerMovement;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnEnable()
    {
        _playerMovement.OnMovementStateChanged += UpdateAnimation;
    }

    private void OnDisable()
    {
        _playerMovement.OnMovementStateChanged -= UpdateAnimation;
    }

    private void UpdateAnimation(MovementState state) 
    {
        switch (state)
        {
            case MovementState.idle:
                _animator.SetBool("IsMove", false);
                break;
            case MovementState.move:
                _animator.SetBool("IsMove", true);
                break;
        }

    }

}