using UnityEngine;

public class MainMenu : MenuBase
{
    public void PlayGame()
    {
        SceneController.LoadScene("Gameplay");
    }

    public void Quit()
    {
        QuitGame();
    }
}