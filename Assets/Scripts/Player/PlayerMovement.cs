using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(PlayerCombat))]
public class PlayerMovement : MonoBehaviour
{

    public Action<MovementState> OnMovementStateChanged;

    [SerializeField] private PointsNavigator _navigator;
    [SerializeField] private MovementState _movementState;
    [SerializeField] private Point _currentPoint;
    [SerializeField] private Button _buttonStart;
    [SerializeField, Min(0)] private float _speed = 3.5f;
    private LevelLoader _levelLoader;
    private NavMeshAgent _agent;
    private PlayerCombat _combat;


    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = _speed;
        _combat = GetComponent<PlayerCombat>();
        _combat.enabled = false;
    }

    private void OnEnable()
    {
        _buttonStart?.onClick.AddListener(StartGame);
    }

    private void OnDisable()
    {
        _buttonStart?.onClick.RemoveListener(StartGame);
    }

    public void Consturctor(PointsNavigator navigator, Button buttonStart, LevelLoader levelLoader) 
    {
        _navigator = navigator;
        _levelLoader = levelLoader;
        _buttonStart = buttonStart;
        _buttonStart.onClick.AddListener(StartGame);
    }
    private void StartGame() 
    {
        _combat.enabled = true;
        _currentPoint = _navigator.FirstPoint;
        UpdateAgentDestination(_currentPoint.transform.position);
        _currentPoint.OnComplite += MoveNextPoint;
    }

    private void MoveNextPoint() 
    {
        _currentPoint.OnComplite -= MoveNextPoint;
        if (_navigator.LastPoint == _currentPoint) 
            return;
        _currentPoint = _navigator.GetNextPoint(_currentPoint);
        UpdateAgentDestination(_currentPoint.transform.position);
        _currentPoint.OnComplite += MoveNextPoint;
        if (_navigator.LastPoint == _currentPoint)
            _currentPoint.OnComplite += _levelLoader.Restart;
    }

    private void UpdateAgentDestination(Vector3 target)
    {
        _agent.SetDestination(target);
        UpdateMovementState(MovementState.move);
    }

    private void UpdateMovementState(MovementState state) 
    {
        _movementState = state;
        OnMovementStateChanged?.Invoke(state);
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Point point)) 
        {
            if (!point.Complite)
                UpdateMovementState(MovementState.idle);
            else
                MoveNextPoint();
        }
    }
}
