using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void PauseGame()
    {
        PauseMenu.SetActive(true);
    }
    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
    }
    public void GoBackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
