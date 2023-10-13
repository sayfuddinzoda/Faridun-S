using UnityEngine;

[RequireComponent(typeof(Animator))]
public sealed class EnemyAnimator : MonoBehaviour
{

    private Animator _animator;

    [SerializeField, Range(1,3)] private float _randomSpeedMin;
    [SerializeField, Range(1,3)] private float _randomSpeedMax;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _animator.speed = Random.Range(_randomSpeedMin, _randomSpeedMax);
    }

}
