using System;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public event Action<Collision2D> GroundEntered;
    public event Action GroundExited;
    public event Action<Collision2D, Enemy> EnemyTouched;
    public event Action DeathLevelTouched;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out _))
            GroundEntered?.Invoke(collision);
        else if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
            EnemyTouched?.Invoke(collision, enemy);
        else if (collision.gameObject.TryGetComponent<DeathLevel>(out _))
            DeathLevelTouched?.Invoke();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out _))
            GroundExited?.Invoke();
    }
}
