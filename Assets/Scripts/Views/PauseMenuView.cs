using UnityEngine;
using UnityEngine.UI;

public class PauseMenuView : MenuBaseView, IPauseMenuView
{
    [SerializeField] private GameObject pauseContainer;
    [SerializeField] private KeyCode pauseButton = KeyCode.Escape;

    [SerializeField] private Button resumeButton;
    [SerializeField] private Button menuButton;
    [SerializeField] private Button quitButton;

    private IPauseMenuPresenter pauseMenuPresenter;
    private PauseMenuViewModel pauseMenuViewModel;

    private const string altPauseButtonName = "Cancel";

    private void Start()
    {
        resumeButton.onClick.AddListener(ResumeGame);
        menuButton.onClick.AddListener(GoToMenu);
        quitButton.onClick.AddListener(Quit);
    }

    private void Update()
    {
        if ((Input.GetKeyDown(pauseButton) || Input.GetButtonDown(altPauseButtonName)) && pauseMenuPresenter.CanPauseGame())
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

    public void GoToMenu()
    {
        pauseMenuPresenter.TogglePause();
        pauseMenuPresenter.GoToMenu();
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