using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel; 

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            pausePanel.SetActive(isPaused);

            if (isPaused)
            {
                Time.timeScale = 0f; // Зупиняє гру
            }
            else
            {
                Time.timeScale = 1f; // Продовжує гру
            }
        }
    }
    public void Resume()
    {
        pausePanel.SetActive(!isPaused);
        Time.timeScale = 1f;
    }
    public void loadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
