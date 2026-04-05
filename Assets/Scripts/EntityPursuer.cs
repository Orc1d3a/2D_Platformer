using UnityEngine;

public class EntityPursuer : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _smoothTime = 0.2f;

    private Vector3 _targetPosition;
    private Vector3 _currentVelocity = Vector3.zero;

    private float _minDistanceToTarget = 0.1f;

    private void Awake()
    {
        transform.position = new Vector3(_target.position.x + _offset.x, _target.position.y + _offset.y, transform.position.z);
        
        _targetPosition = transform.position;
    }

    private void LateUpdate()
    {
        _targetPosition.x = _target.position.x + _offset.x;
        _targetPosition.y = _target.position.y + _offset.y;

        if (Vector2.Distance(transform.position, _targetPosition) > _minDistanceToTarget)
            transform.position = Vector3.SmoothDamp(transform.position, _targetPosition, ref _currentVelocity, _smoothTime);
    }
}
