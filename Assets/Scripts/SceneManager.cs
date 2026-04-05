using UnityEngine.SceneManagement;
using UnityEngine;

public class Scene : MonoBehaviour
{
    [SerializeField] Health _playerHealth;

    private void OnEnable()
    {
        _playerHealth.Died += RestartScene;
    }

    private void OnDisable()
    {
        _playerHealth.Died -= RestartScene;
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
