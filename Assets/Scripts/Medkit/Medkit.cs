using System;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    public event Action<Medkit> ShoudBeDestroyed;

    public float HealValue { get; private set; } = 2;

    public void Destroy()
    {
        ShoudBeDestroyed?.Invoke(this);
    }
}
