using UnityEngine;

public class GroundedStatusHandler : MonoBehaviour
{
    private int _groundContactsQuantiti = 0;

    public bool IsGrounded { get; private set; }

    public void SetGrounded()
    {
        IsGrounded = true;

        _groundContactsQuantiti++;
    }

    public void SetAirborne()
    {
        if (_groundContactsQuantiti > 0)
        {
            _groundContactsQuantiti--;

            if (_groundContactsQuantiti == 0)
                IsGrounded = false;
        }
    }
}
