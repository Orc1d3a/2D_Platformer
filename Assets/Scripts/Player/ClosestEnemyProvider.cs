using System.Linq;
using UnityEngine;

public class ClosestEnemyProvider : MonoBehaviour
{
    [SerializeField] private float _radius = 0.5f;

    public Enemy ClosestEnemy { get; private set; } = null;

    private void Update()
    {
        CheckIsEnemyChanged();
    }

    public void CheckIsEnemyChanged()
    {
        Enemy[] enemies = Physics2D.OverlapCircleAll(transform.position, _radius).Select(collider => collider.GetComponent<Enemy>()).Where(enemy => enemy != null).ToArray();
        Enemy closestEnemy = null;

        if (enemies.Length > 0)
        {
            float minDistance = float.MaxValue;
            float currentEnemyDistance;

            foreach (Enemy enemy in enemies)
            {
                currentEnemyDistance = (transform.position - enemy.transform.position).sqrMagnitude;

                if (minDistance > currentEnemyDistance)
                {
                    closestEnemy = enemy;
                    minDistance = currentEnemyDistance;
                }
            }
        }

        ClosestEnemy = closestEnemy;
    }
}
