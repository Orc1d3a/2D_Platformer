using System;
using UnityEngine;

public class CoinPurse : MonoBehaviour
{
    public event Action<int> CoinsQuantitiChanged;

    private CoinDetector _coinDetector;
    private CollisionHandler _collisionHandler;

    public int Coins { get; private set; } = 0;

    private void Awake()
    {
        _coinDetector = GetComponent<CoinDetector>();
        _collisionHandler = GetComponent<CollisionHandler>();
    }

    private void OnEnable()
    {
        _coinDetector.CoinDetected += AddCoin;
        _collisionHandler.EnemyTouched += RemoveCoin;
    }

    private void OnDisable()
    {
        _coinDetector.CoinDetected -= AddCoin;
        _collisionHandler.EnemyTouched -= RemoveCoin;
    }

    private void AddCoin()
    {
        Coins++;

        CoinsQuantitiChanged?.Invoke(Coins);
    }

    private void RemoveCoin()
    {
        Coins--;

        CoinsQuantitiChanged?.Invoke(Coins);
    }
}
