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
        _enemyMover.GoalChanged += FlipSprite;
    }

    private void OnDisable()
    {
        _enemyMover.GoalChanged -= FlipSprite;
    }

    private void FlipSprite(Transform goal)
    {
        if (transform.position.x > goal.position.x)
            Rotator.RotateLeft(gameObject);
        else
            Rotator.RotateRight(gameObject);
    }
}
