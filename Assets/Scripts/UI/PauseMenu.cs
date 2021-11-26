using UnityEngine;

public class PauseMenu : MenuBase
{
    [SerializeField] private GameObject pauseContainer;
    [SerializeField] private KeyCode pauseButton = KeyCode.Escape;

    private bool isGamePaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(pauseButton))
        {
            TogglePause();
            pauseContainer.SetActive(isGamePaused);
        }
    }

    private void TogglePause()
    {
        isGamePaused = !isGamePaused;

        if (isGamePaused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public void GoToMenu()
    {
        TogglePause();
        SceneController.LoadScene("Menu");
    }

    public void ResumeGame()
    {
        TogglePause();
        pauseContainer.SetActive(false);
    }

    public void Quit()
    {
        QuitGame();
    }
}