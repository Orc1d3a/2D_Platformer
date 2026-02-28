using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Mover : MonoBehaviour
{
    [SerializeField] private GroundedStatusHandler _groundDetector;

    private Rigidbody2D _rigidbody;

    private Vector2 _direction = new Vector2();

    private float _speed = 4f;
    private float _jumpForce = 8f;

    public Vector2 Direction => _direction;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        _direction.x = Input.GetAxis("Horizontal");

        if (_direction.x != 0)
        {
            transform.Translate(_direction * _speed * Time.deltaTime);
        }
    }

    private void Jump()
    {
        if (_groundDetector.IsGrounded && Input.GetAxis("Jump") > 0)
        {
            _rigidbody.velocity = Vector2.up * _jumpForce;
        }
    }
}
