using System;
using UnityEngine;

public class CoinPurse : MonoBehaviour
{
    [SerializeField] private CoinDetector _coinDetector;
    [SerializeField] private CollisionHandler _collisionHandler;

    public event Action<int> CoinsQuantitiChanged;

    public int Coins { get; private set; } = 0;

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
