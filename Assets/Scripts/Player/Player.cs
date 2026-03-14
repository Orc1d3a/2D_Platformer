using System;
using UnityEngine;

[RequireComponent(typeof(CoinPurse))]
[RequireComponent(typeof(TriggerHandler))]
[RequireComponent(typeof(CollisionHandler))]
[RequireComponent(typeof(GroundedStatusHandler))]

public class Player : MonoBehaviour
{
    public event Action Died;

    private CoinPurse _coinPurse;
    private TriggerHandler _triggerHandler;

    private CollisionHandler _collisionHandler;
    private GroundedStatusHandler _groundedStatusHandler;
    private Mover _mover;
    private Saver _saver;

    private int _maxHealth = 5;
    private int _health;

    private void Awake()
    {
        _triggerHandler = GetComponent<TriggerHandler>();
        _coinPurse = GetComponent<CoinPurse>();
        _collisionHandler = GetComponent<CollisionHandler>();
        _groundedStatusHandler = GetComponent<GroundedStatusHandler>();
        _mover = GetComponent<Mover>();
        _saver = GetComponent<Saver>();

        _health = _maxHealth;
    }

    private void OnEnable()
    {
        _triggerHandler.CoinTouched += AddCoin;
        _triggerHandler.MedkitTouched += Heal;

        _collisionHandler.EnemyTouched += HandleEnemyTouch;
        _collisionHandler.GroundEntered += SetGrounded;
        _collisionHandler.GroundExited += SetAirborne;
        _collisionHandler.DeathLevelTouched += Save;
    }

    private void OnDisable()
    {
        _triggerHandler.CoinTouched -= AddCoin;
        _collisionHandler.EnemyTouched -= HandleEnemyTouch;
        _collisionHandler.GroundEntered -= SetGrounded;
        _collisionHandler.GroundExited -= SetAirborne;
        _collisionHandler.DeathLevelTouched -= Save;
    }

    private void AddCoin()
    {
        _coinPurse.AddCoin();
    }

    private void Heal()
    {
            _health = _maxHealth;
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
        enemy.Die();
    }

    private void TakeDamage(Enemy enemy)
    {
        if (_health > 0)
        {
            _health--;

            _mover.Knockback(enemy.transform);
        }

        if (_health <= 0)
            Died?.Invoke();

        _coinPurse.RemoveCoin();
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

    private void Save()
    {
        _saver.Teleport();
    }
}
