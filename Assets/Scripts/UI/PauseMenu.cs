using System;
using UnityEngine;

public class PauseMenu : MenuBase
{
    [SerializeField] private GameObject pauseContainer;
    [SerializeField] private KeyCode pauseButton = KeyCode.Escape;

    private bool isGamePaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(pauseButton) && CanPauseGame())
        {            
            TogglePause();
            pauseContainer.SetActive(isGamePaused);                        
        }
    }

    private bool CanPauseGame()
    {
        if (GameOverMenu.IsShowingGameOverMenu())
            return false;

        return true;
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