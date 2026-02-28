using System;
using UnityEngine;

public class GroundedStatusHandler : MonoBehaviour
{
    [SerializeField] private CollisionHandler _collisionHandler;

    public bool IsGrounded { get; private set; }

    private int _groundContactsQuantiti = 0;

    private void OnEnable()
    {
        _collisionHandler.GroundEntered += SetGrounded;
        _collisionHandler.GroundExited += SetAirborne;
    }

    private void OnDisable()
    {
        _collisionHandler.GroundEntered -= SetGrounded;
        _collisionHandler.GroundExited -= SetAirborne;
    }

    private void SetGrounded(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y > 0.5f)
            {
                IsGrounded = true;

                _groundContactsQuantiti++;

                return;
            }
        }
    }

    private void SetAirborne()
    {
        if (_groundContactsQuantiti > 0)
        {
            _groundContactsQuantiti--;

            if (_groundContactsQuantiti == 0)
                IsGrounded = false;
        }
    }
}
