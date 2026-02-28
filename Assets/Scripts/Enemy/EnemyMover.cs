using System;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform _waypointsParent;

    public event Action WaypointChanged;

    private Transform[] _waypoints;

    private int _currentWaypoint = 0;
    private float _minDistanceToWaypoint = 0.1f;

    private float _speed = 3f;

    public Transform Waypoint => _waypoints[_currentWaypoint].transform;

    private void Awake()
    {
        _waypoints = _waypointsParent.GetComponentsInChildren<Transform>();
    }

    private void Update()
    {
        CheckDistance();
        Move();
    }

    private void CheckDistance()
    {
        if (Vector2.Distance(transform.position, _waypoints[_currentWaypoint].position) < _minDistanceToWaypoint)
        {
            _currentWaypoint = (_currentWaypoint + 1) % _waypoints.Length;

            WaypointChanged?.Invoke();
        }
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, _waypoints[_currentWaypoint].position, _speed*Time.deltaTime);
    }
}
