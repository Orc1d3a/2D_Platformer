using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(GroundedStatusHandler))]

public class Mover : MonoBehaviour
{
    private GroundedStatusHandler _groundDetector;
    private Rigidbody2D _rigidbody;

    private Vector2 _direction = new Vector2();

    private float _speed = 4f;
    private float _jumpForce = 8f;
    private float _knockbackForce = 8f;

    public Vector2 Direction => _direction;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _groundDetector = GetComponent<GroundedStatusHandler>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    public void Knockback(Transform enemyPosition)
    {
        Vector2 direction = (transform.position - enemyPosition.position).normalized;

        _rigidbody.velocity = Vector2.zero;
        _rigidbody.AddForce(direction * _knockbackForce, ForceMode2D.Impulse);
    }

    private void Move()
    {
        _direction.x = InputReader.HorizontalAxis;

        if (_direction.x != 0)
        {
            transform.Translate(_direction * _speed * Time.deltaTime, Space.World);
        }
    }

    private void Jump()
    {
        if (_groundDetector.IsGrounded && InputReader.IsJumpPressed)
        {
            _rigidbody.velocity = Vector2.up * _jumpForce;
        }
    }
}
