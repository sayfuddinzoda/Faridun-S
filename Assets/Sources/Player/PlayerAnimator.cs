using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMovement))]
public class PlayerAnimator : MonoBehaviour
{

    [SerializeField] private PlayerMovement _playerMovement;
    private Animator _animator;
    private int _animatorHashIsMove;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
        _animatorHashIsMove = Animator.StringToHash("IsMove");
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
                _animator.SetBool(_animatorHashIsMove, false);
                break;
            case MovementState.move:
                _animator.SetBool(_animatorHashIsMove, true);
                break;
        }

    }

}