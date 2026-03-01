using UnityEngine;

public static class InputReader
{
    public static float HorizontalAxis => Input.GetAxisRaw("Horizontal");
    public static bool IsJumpPressed => Input.GetButtonDown("Jump");
}
