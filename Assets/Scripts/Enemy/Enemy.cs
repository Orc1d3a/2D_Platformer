using UnityEngine;

[RequireComponent (typeof(EnemyMover))]
[RequireComponent (typeof(PlayerDetector))]
[RequireComponent (typeof(Health))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;

    private EnemyMover _enemyMover;
    private PlayerDetector _playerDetector;
    private Health _health;

    public float Damage { get; private set; } = 1;

    private void Awake()
    {
        _enemyMover = GetComponent<EnemyMover>();
        _playerDetector = GetComponent<PlayerDetector>();
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _playerDetector.PlayerDetected += ChangeGoal;
        _playerDetector.PlayerLost += ChangeGoal;
    }

    private void OnDisable()
    {
        _playerDetector.PlayerDetected -= ChangeGoal;
        _playerDetector.PlayerLost -= ChangeGoal;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (TryGetComponent<DeathLevel>(out _))
            Die();
    }

    public void TakeDamage(float value)
    {
        if (_health.CurrentHealth > 0)
        {
            _health.TakeDamage(value);
        }

        if (_health.CurrentHealth <= 0)
            Die();
    }

    public void Die()
    {
        Destroy(_canvas.gameObject);

        Destroy(gameObject);
    }

    private void ChangeGoal(Player player)
    {
        _enemyMover.ChangeGoal(player.transform);
    }

    private void ChangeGoal()
    {
        _enemyMover.ChangeGoal();
    }
}
