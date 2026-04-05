using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public event Action<Player> PlayerDetected;
    public event Action PlayerLost;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
            PlayerDetected?.Invoke(player);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
            PlayerLost?.Invoke();
    }
}
