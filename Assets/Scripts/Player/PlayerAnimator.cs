using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Animator))]

public class PlayerAnimator : MonoBehaviour
{
    private Mover _mover;
    private Animator _animator;

    private float _speed;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _speed = _mover.Direction.sqrMagnitude;

        _animator.SetFloat("Speed", _speed);

        if (_mover.Direction.x < 0)
        {
            Rotator.RotateLeft(gameObject);
        }
        else if(_mover.Direction.x > 0)
        {
            Rotator.RotateRight(gameObject);
        }
    }
}
