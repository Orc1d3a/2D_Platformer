using System;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    public event Action<Medkit> ShoudBeDestroyed;

    public void Destroy()
    {
        ShoudBeDestroyed?.Invoke(this);
    }
}
