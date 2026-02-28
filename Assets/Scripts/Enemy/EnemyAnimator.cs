using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private EnemyMover _enemyMover;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
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
            _spriteRenderer.flipX = true;
        else
            _spriteRenderer.flipX = false;
    }
}
