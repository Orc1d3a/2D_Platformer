using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyMover _enemyMover;
    [SerializeField] private PlayerDetector _playerDetector;

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

    public void Die()
    {
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
