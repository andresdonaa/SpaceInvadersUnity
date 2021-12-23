using UnityEngine;
using UnityEngine.UI;

public class PauseMenuView : MenuBase, IPauseMenuView
{
    [SerializeField] private GameObject pauseContainer;
    [SerializeField] private KeyCode pauseButton = KeyCode.Escape;

    [SerializeField] private Button resumeButton;
    [SerializeField] private Button menuButton;
    [SerializeField] private Button quitButton;

    private IPauseMenuPresenter pauseMenuPresenter;
    private PauseMenuViewModel pauseMenuViewModel;

    private void Start()
    {
        resumeButton.onClick.AddListener(ResumeGame);
        menuButton.onClick.AddListener(GoToMenu);
        quitButton.onClick.AddListener(Quit);        
    }

    private void Update()
    {
        if (Input.GetKeyDown(pauseButton) && CanPauseGame())
        {
            pauseMenuPresenter.TogglePause();
            pauseContainer.SetActive(pauseMenuViewModel.IsGamePaused);
        }
    }

    private void OnDestroy()
    {
        resumeButton.onClick.RemoveListener(ResumeGame);
        menuButton.onClick.RemoveListener(GoToMenu);
        quitButton.onClick.RemoveListener(Quit);
    }

    public void Configure(PauseMenuViewModel pauseMenuViewModel, IPauseMenuPresenter pauseMenuPresenter)
    {
        this.pauseMenuPresenter = pauseMenuPresenter;
        this.pauseMenuViewModel = pauseMenuViewModel;
    }

    private bool CanPauseGame()
    {
        if (GameOverMenuViewModel.IsGameOverMenuActive)
            return false;

        return true;
    }   

    public void GoToMenu()
    {
        pauseMenuPresenter.TogglePause();
        SceneController.LoadScene("Menu");
    }

    public void ResumeGame()
    {
        pauseMenuPresenter.TogglePause();
        pauseContainer.SetActive(false);
    }

    public void Quit()
    {
        QuitGame();
    }
}

public class PauseMenuPresenter : IPauseMenuPresenter
{
    private IPauseMenuView pauseMenuView;
    private PauseMenuViewModel pauseMenuViewModel;

    public PauseMenuPresenter(IPauseMenuView pauseMenuView, PauseMenuViewModel pauseMenuViewModel)
    {
        this.pauseMenuViewModel = pauseMenuViewModel;
        this.pauseMenuView = pauseMenuView;
    }

    public void TogglePause()
    {
        pauseMenuViewModel.IsGamePaused = !pauseMenuViewModel.IsGamePaused;

        if (pauseMenuViewModel.IsGamePaused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
}

public class PauseMenuViewModel
{
    public bool IsGamePaused { get; set; } = false;    
}

public interface IPauseMenuPresenter
{
    void TogglePause();
}

public interface IPauseMenuView
{
    void Configure(PauseMenuViewModel pauseMenuViewModel, IPauseMenuPresenter pauseMenuPresenter);
}