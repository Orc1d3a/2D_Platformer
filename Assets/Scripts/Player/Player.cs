using System;
using UnityEngine;

[RequireComponent(typeof(CoinPurse))]
[RequireComponent(typeof(TriggerHandler))]
[RequireComponent(typeof(CollisionHandler))]
[RequireComponent(typeof(GroundedStatusHandler))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Vampirism))]

public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    private CoinPurse _coinPurse;
    private TriggerHandler _triggerHandler;

    private CollisionHandler _collisionHandler;
    private GroundedStatusHandler _groundedStatusHandler;
    private Mover _mover;
    private Saver _saver;
    private Health _health;

    private Vampirism _vampirism;

    private float _damage = 1;

    private void Awake()
    {
        _triggerHandler = GetComponent<TriggerHandler>();
        _coinPurse = GetComponent<CoinPurse>();
        _collisionHandler = GetComponent<CollisionHandler>();
        _groundedStatusHandler = GetComponent<GroundedStatusHandler>();
        _mover = GetComponent<Mover>();
        _saver = GetComponent<Saver>();
        _health = GetComponent<Health>();
        _vampirism = GetComponent<Vampirism>();
    }

    private void OnEnable()
    {
        _triggerHandler.CoinTouched += AddCoin;
        _triggerHandler.MedkitTouched += Heal;

        _collisionHandler.EnemyTouched += HandleEnemyTouch;
        _collisionHandler.GroundEntered += SetGrounded;
        _collisionHandler.GroundExited += SetAirborne;
        _collisionHandler.DeathLevelTouched += HandleDeathLevelTouch;

        _inputReader.VampirismPressed += StartVampirism;
    }

    private void OnDisable()
    {
        _triggerHandler.CoinTouched -= AddCoin;
        _triggerHandler.MedkitTouched -= Heal;

        _collisionHandler.EnemyTouched -= HandleEnemyTouch;
        _collisionHandler.GroundEntered -= SetGrounded;
        _collisionHandler.GroundExited -= SetAirborne;
        _collisionHandler.DeathLevelTouched -= HandleDeathLevelTouch;

        _inputReader.VampirismPressed -= StartVampirism;
    }

    private void AddCoin()
    {
        _coinPurse.AddCoin();
    }

    private void Heal(float value)
    {
        _health.Heal(value);
    }

    private void HandleEnemyTouch(Collision2D collision, Enemy enemy)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y > 0.5f)
            {
                Attack(enemy);

                return;
            }
        }

        TakeDamage(enemy);
    }

    private void Attack(Enemy enemy)
    {
        enemy.TakeDamage(_damage);
    }

    private void TakeDamage(Enemy enemy)
    {
        if (_health.CurrentHealth > 0)
        {
            _health.TakeDamage(enemy.Damage);

            _mover.Knockback(enemy.transform);
        }
    }

    private void SetGrounded(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y > 0.5f)
            {
                _groundedStatusHandler.SetGrounded();

                return;
            }
        }
    }

    private void SetAirborne()
    {
        _groundedStatusHandler.SetAirborne();
    }

    private void HandleDeathLevelTouch()
    {
        float damage = 1;

        _health.TakeDamage(damage);

        _saver.Teleport();
    }

    private void StartVampirism()
    {
        _vampirism.Work();
    }
}
