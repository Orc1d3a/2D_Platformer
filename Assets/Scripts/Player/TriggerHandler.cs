using System;
using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
    public event Action CoinTouched;
    public event Action MedkitTouched;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            CoinTouched?.Invoke();

            coin.Destroy();
        }
        else if (collision.TryGetComponent(out Medkit medkit))
        {
            MedkitTouched?.Invoke();

            medkit.Destroy();
        }
    }
}
