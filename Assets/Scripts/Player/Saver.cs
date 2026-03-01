using UnityEngine;

public class Saver : MonoBehaviour
{
    private CollisionHandler _collisionHandler;

    private Vector3 _defaultPosition = new Vector3(-3,0,0);

    private void Awake()
    {
        _collisionHandler = GetComponent<CollisionHandler>();
    }

    private void OnEnable()
    {
        _collisionHandler.DeathLevelTouched += Teleport;
        _collisionHandler.EnemyTouched += Teleport;
    }

    private void OnDisable()
    {
        _collisionHandler.DeathLevelTouched -= Teleport;
        _collisionHandler.EnemyTouched -= Teleport;
    }

    private void Teleport()
    {
        transform.position = _defaultPosition;
    }
}
