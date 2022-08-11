using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimator : MonoBehaviour
{

    [SerializeField] private Animator _animator;
    [SerializeField, Range(1,3)] private float _randomSpeedMin;
    [SerializeField, Range(1,3)] private float _randomSpeedMax;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _animator.speed = Random.Range(_randomSpeedMin, _randomSpeedMax);
    }

}
