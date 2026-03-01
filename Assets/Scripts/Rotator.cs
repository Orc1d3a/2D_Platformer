using UnityEngine;

public static class Rotator
{
    public static void RotateLeft(GameObject gameObject)
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    public static void RotateRight(GameObject gameObject)
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
