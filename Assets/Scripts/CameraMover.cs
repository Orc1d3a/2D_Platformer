using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private Vector3 _targetPosition;
    private Vector3 _currentVelocity = Vector3.zero;

    private float _smoothTime = 0.2f;
    private float _minDistanceToPlayer = 0.1f;

    private void Awake()
    {
        _targetPosition = transform.position;
    }

    private void LateUpdate()
    {
        _targetPosition.x = _player.position.x;
        _targetPosition.y = _player.position.y;

        if (Vector2.Distance(transform.position, _targetPosition) > _minDistanceToPlayer)
            transform.position = Vector3.SmoothDamp(transform.position, _targetPosition, ref _currentVelocity, _smoothTime);
    }
}
