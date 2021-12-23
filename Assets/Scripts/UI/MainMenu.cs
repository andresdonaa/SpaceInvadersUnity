using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MenuBase
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;

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

    public void PlayGame()
    {
        SceneController.LoadScene("Gameplay");
    }

    public void Quit()
    {
        QuitGame();
    }
}