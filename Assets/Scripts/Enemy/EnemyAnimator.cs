using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class EnemyAnimator : MonoBehaviour
{
    private EnemyMover _enemyMover;

    private void Awake()
    {
        _enemyMover = GetComponent<EnemyMover>();
    }

    private void OnEnable()
    {
        _enemyMover.WaypointChanged += FlipSprite;
    }

    private void OnDisable()
    {
        _enemyMover.WaypointChanged -= FlipSprite;
    }

    private void FlipSprite()
    {
        if (transform.position.x > _enemyMover.Waypoint.position.x)
            Rotator.RotateLeft(gameObject);
        else
            Rotator.RotateRight(gameObject);
    }
}
