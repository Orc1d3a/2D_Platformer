using System;
using UnityEngine;

public class CoinPurse : MonoBehaviour
{
    public event Action<int> CoinsQuantitiChanged;

    public int Coins { get; private set; } = 0;

    public void AddCoin()
    {
        Coins++;

        CoinsQuantitiChanged?.Invoke(Coins);
    }

    public void RemoveCoin()
    {
        if (Coins > 0)
        {
            Coins--;

            CoinsQuantitiChanged?.Invoke(Coins);
        }
    }
}
