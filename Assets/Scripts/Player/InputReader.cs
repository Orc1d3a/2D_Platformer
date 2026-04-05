using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action VampirismPressed;

    private KeyCode _vampirism = KeyCode.E;

    public float HorizontalAxis => Input.GetAxisRaw("Horizontal");
    public bool IsJumpPressed => Input.GetButtonDown("Jump");

    private void Update()
    {
        if (Input.GetKeyDown(_vampirism))
        {
            VampirismPressed?.Invoke();
        }
    }
}
