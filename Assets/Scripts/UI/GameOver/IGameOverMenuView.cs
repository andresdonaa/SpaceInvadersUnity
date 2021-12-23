public interface IGameOverMenuView
{
    void Configure(GameOverMenuViewModel gameOverMenuViewModel, IGameOverMenuPresenter gameOverMenuPresenter);
    void GameOver();
}
