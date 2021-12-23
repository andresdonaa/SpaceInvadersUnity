using Scripts.Events;
using SuperMaxim.Messaging;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenuView : MenuBase, IGameOverMenuView
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
        Messenger.Default.Subscribe<GameOverEvent>(OnGameOverEvent);
    }

    private void Start()
    {
        playAgainButton.onClick.AddListener(PlayAgain);
        menuButton.onClick.AddListener(GoToMenu);
        quitButton.onClick.AddListener(Quit);
    }

    private void OnDestroy()
    {
        Messenger.Default.Unsubscribe<GameOverEvent>(OnGameOverEvent);

        playAgainButton.onClick.RemoveListener(PlayAgain);
        menuButton.onClick.RemoveListener(GoToMenu);
        quitButton.onClick.RemoveListener(Quit);
    }

    public void Configure(GameOverMenuViewModel gameOverMenuViewModel, IGameOverMenuPresenter gameOverMenuPresenter)
    {
        this.gameOverMenuPresenter = gameOverMenuPresenter;
        this.gameOverMenuViewModel = gameOverMenuViewModel;
    }

    private void OnGameOverEvent(GameOverEvent gameOverEvent)
    {
        gameOverContainer.SetActive(true);
        GameOverMenuViewModel.IsGameOverMenuActive = true;
    }

    public void GoToMenu()
    {
        SceneController.LoadScene("Menu");
    }

    public void PlayAgain()
    {
        SceneController.ReloadScene();
    }

    public void Quit()
    {
        QuitGame();
    }
}

public interface IGameOverMenuView
{
    void Configure(GameOverMenuViewModel gameOverMenuViewModel, IGameOverMenuPresenter gameOverMenuPresenter);
}

public interface IGameOverMenuPresenter
{
    
}

public class GameOverMenuPresenter : IGameOverMenuPresenter
{
    private IGameOverMenuView gameOverMenuViewInstance;
    private GameOverMenuViewModel gameOverMenuViewModel;

    public GameOverMenuPresenter(IGameOverMenuView gameOverMenuViewInstance, GameOverMenuViewModel gameOverMenuViewModel)
    {
        this.gameOverMenuViewInstance = gameOverMenuViewInstance;
        this.gameOverMenuViewModel = gameOverMenuViewModel;
    }
}