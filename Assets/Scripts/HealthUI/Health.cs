using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action HealthChanged;

    public float MaxHealth { get; private set; } = 3f;
    public float CurrentHealth { get; private set; }

    private void Awake()
    {
        CurrentHealth = MaxHealth;
        HealthChanged?.Invoke();
    }

    public void TakeDamage(float value)
    {
        if (CurrentHealth > 0)
            CurrentHealth -= value;

        if (CurrentHealth < 0)
            CurrentHealth = 0;

        HealthChanged?.Invoke();
    }

    public void Heal(float value)
    {
        if (CurrentHealth < MaxHealth)
            CurrentHealth += value;

        if (CurrentHealth > MaxHealth)
            CurrentHealth = MaxHealth;

        HealthChanged?.Invoke();
    }
}
