public class MainMenuPresenter : IMainMenuPresenter
{
    private IMainMenuView mainMenuView;

    public MainMenuPresenter(IMainMenuView mainMenuView)
    {
        this.mainMenuView = mainMenuView;
    }

    public void PlayGame()
    {
        SceneController.LoadScene("Gameplay");
    }
}
