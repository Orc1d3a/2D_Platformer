using UnityEngine.SceneManagement;
using UnityEngine;

public class Scene : MonoBehaviour
{
    [SerializeField] Player _player;

    private void OnEnable()
    {
        _player.Died += RestartScene;
    }

    private void OnDisable()
    {
        _player.Died -= RestartScene;
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
