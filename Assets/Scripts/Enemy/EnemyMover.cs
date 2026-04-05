using System;
using System.Linq;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform _waypointsParent;

    public event Action<Transform> GoalChanged;

    private Transform[] _waypoints;
    private Transform _goal;

    private int _currentWaypoint = 0;
    private float _minDistanceToWaypoint = 0.1f;

    private float _speed = 3f;

    private bool _doSeePlayer = false;

    private void Awake()
    {
        _waypoints = _waypointsParent.GetComponentsInChildren<Transform>().Where(transform => transform != _waypointsParent.transform).ToArray();

        ChangeGoal();
    }

    private void Update()
    {
        if (_doSeePlayer == false)
            CheckDistance();

        Move();
    }

    public void ChangeGoal(Transform newGoal)
    {
        _goal = newGoal;

        ApplyGoalChanges(true);

    }

    public void ChangeGoal()
    {
        _goal = _waypoints[_currentWaypoint];

        ApplyGoalChanges(false);
    }

    private void ApplyGoalChanges(bool doSeePlayer)
    {
        _doSeePlayer = doSeePlayer;

        GoalChanged?.Invoke(_goal);
    }

    private void CheckDistance()
    {
        if (Vector2.Distance(transform.position, _waypoints[_currentWaypoint].position) < _minDistanceToWaypoint)
        {
            _currentWaypoint = (_currentWaypoint + 1) % _waypoints.Length;
            _goal = _waypoints[_currentWaypoint];

            GoalChanged?.Invoke(_goal);
        }
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, _goal.position, _speed * Time.deltaTime);
    }
}
