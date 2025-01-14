using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUIHandler : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
