using UnityEngine;
using UnityEngine.UI;

public class GameOverMenuView : MenuBaseView, IGameOverMenuView
{
    [SerializeField] private GameObject gameOverContainer;
    [SerializeField] private Button playAgainButton;
    [SerializeField] private Button menuButton;
    [SerializeField] private Button quitButton;

    private IGameOverMenuPresenter gameOverMenuPresenter;
    private GameOverMenuViewModel gameOverMenuViewModel;

    private void Awake()
    {
        GameOverMenuViewModel.IsGameOverMenuActive = false;
    }

    private void Start()
    {
        playAgainButton.onClick.AddListener(PlayAgain);
        menuButton.onClick.AddListener(GoToMenu);
        quitButton.onClick.AddListener(Quit);
    }

    private void OnDestroy()
    {
        gameOverMenuPresenter.Dispose();

        playAgainButton.onClick.RemoveListener(PlayAgain);
        menuButton.onClick.RemoveListener(GoToMenu);
        quitButton.onClick.RemoveListener(Quit);
    }

    public void Configure(GameOverMenuViewModel gameOverMenuViewModel, IGameOverMenuPresenter gameOverMenuPresenter)
    {
        this.gameOverMenuPresenter = gameOverMenuPresenter;
        this.gameOverMenuViewModel = gameOverMenuViewModel;
    }

    public void GameOver()
    {
        gameOverContainer.SetActive(true);
        GameOverMenuViewModel.IsGameOverMenuActive = true;
    }

    public void GoToMenu()
    {
        gameOverMenuPresenter.GoToMenu();
    }

    public void PlayAgain()
    {
        gameOverMenuPresenter.PlayAgain();
    }

    public void Quit()
    {
        QuitGame();
    }
}