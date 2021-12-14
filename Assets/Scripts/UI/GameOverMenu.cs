using Scripts.Events;
using SuperMaxim.Messaging;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MenuBase
{
    [SerializeField] private GameObject gameOverContainer;
    [SerializeField] private Button playAgainButton;
    [SerializeField] private Button menuButton;
    [SerializeField] private Button quitButton;

    private static bool isGameOverMenuActive;

    private void Awake()
    {
        isGameOverMenuActive = false;
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

    private void OnGameOverEvent(GameOverEvent gameOverEvent)
    {
        gameOverContainer.SetActive(true);
        isGameOverMenuActive = true;
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

    public static bool IsShowingGameOverMenu()
    {
        return isGameOverMenuActive;
    }
}