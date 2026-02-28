using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class PlayerAnimator : MonoBehaviour
{
    private Mover _mover;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private float _speed;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _speed = _mover.Direction.sqrMagnitude;

        _animator.SetFloat("Speed", _speed);

        if (_mover.Direction.x < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if(_mover.Direction.x > 0)
        {
            _spriteRenderer.flipX = false;
        }
    }
}
