using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : MenuBaseView, IMainMenuView
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;

    private IMainMenuPresenter mainMenuPresenter;

    private void Start()
    {
        playButton.onClick.AddListener(PlayGame);        
        quitButton.onClick.AddListener(Quit);
    }

    private void OnDestroy()
    {
        playButton.onClick.RemoveListener(PlayGame);
        quitButton.onClick.RemoveListener(Quit);
    }

    public void Configure(IMainMenuPresenter mainMenuPresenter)
    {        
        this.mainMenuPresenter = mainMenuPresenter;
    }

    private void PlayGame()
    {
        mainMenuPresenter.PlayGame();        
    }

    private void Quit()
    {
        QuitGame();
    }
}
