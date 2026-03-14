using System.Linq;
using UnityEngine;

public class MedkitSpawner : MonoBehaviour
{
    [SerializeField] Medkit _medkitPrefab;

    private Transform[] _spawnPoints;

    private void Awake()
    {
        _spawnPoints = GetComponentsInChildren<Transform>().Where(transform => transform != this.transform).ToArray();
    }

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        Medkit medkit = Instantiate(_medkitPrefab);
        medkit.transform.position = GetRandomPosition();

        medkit.ShoudBeDestroyed += DestroyMedkit;
    }

    private Vector2 GetRandomPosition()
    {
        int positionIndex = Random.Range(0, _spawnPoints.Length);

        return _spawnPoints[positionIndex].position;
    }

    private void DestroyMedkit(Medkit medkit)
    {
        medkit.ShoudBeDestroyed -= DestroyMedkit;

        Destroy(medkit.gameObject);
    }
}
