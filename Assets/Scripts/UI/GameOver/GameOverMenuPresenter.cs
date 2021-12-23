using Scripts.Events;
using SuperMaxim.Messaging;

public class GameOverMenuPresenter : IGameOverMenuPresenter
{
    private IGameOverMenuView gameOverMenuViewInstance;
    private GameOverMenuViewModel gameOverMenuViewModel;

    public GameOverMenuPresenter(IGameOverMenuView gameOverMenuViewInstance, GameOverMenuViewModel gameOverMenuViewModel)
    {
        this.gameOverMenuViewInstance = gameOverMenuViewInstance;
        this.gameOverMenuViewModel = gameOverMenuViewModel;

        Subscribe();
    }

    private void Subscribe()
    {
        Messenger.Default.Subscribe<GameOverEvent>(OnGameOverEvent);
    }

    public void Dispose()
    {
        Messenger.Default.Unsubscribe<GameOverEvent>(OnGameOverEvent);
    }

    private void OnGameOverEvent(GameOverEvent gameOverEvent)
    {
        gameOverMenuViewInstance.GameOver();
    }

    public void GoToMenu()
    {
        SceneController.LoadScene("Menu");
    }

    public void PlayAgain()
    {
        SceneController.ReloadScene();
    }
}