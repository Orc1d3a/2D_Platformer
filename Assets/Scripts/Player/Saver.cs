using UnityEngine;

public class Saver : MonoBehaviour
{
    private Vector3 _defaultPosition = new Vector3(-3,0,0);

    public void Teleport()
    {
        transform.position = _defaultPosition;
    }
}
