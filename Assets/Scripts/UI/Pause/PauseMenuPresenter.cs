using UnityEngine;

public class PauseMenuPresenter : IPauseMenuPresenter
{
    private IPauseMenuView pauseMenuView;
    private PauseMenuViewModel pauseMenuViewModel;

    public PauseMenuPresenter(IPauseMenuView pauseMenuView, PauseMenuViewModel pauseMenuViewModel)
    {
        this.pauseMenuViewModel = pauseMenuViewModel;
        this.pauseMenuView = pauseMenuView;
    }

    public void GoToMenu()
    {
        SceneController.LoadScene("Menu");
    }

    public void TogglePause()
    {
        pauseMenuViewModel.IsGamePaused = !pauseMenuViewModel.IsGamePaused;

        if (pauseMenuViewModel.IsGamePaused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public bool CanPauseGame()
    {
        if (GameOverMenuViewModel.IsGameOverMenuActive)
            return false;

        return true;
    }
}
