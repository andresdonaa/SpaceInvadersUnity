using Scripts.Events;
using SuperMaxim.Messaging;
using System.Threading.Tasks;
using UnityEngine;

public class GameOverController
{
    public GameOverController()
    {
        Subscribe();
    }

    private void Subscribe()
    {
        Messenger.Default.Subscribe<GameOverEvent>(OnGameOver);
    }

    private void OnGameOver(GameOverEvent gameOverEvent)
    {
        Debug.Log("Game Over!");
        RestartGame(1000);
    }

    private async void RestartGame(int milisecondsAfter)
    {
        await Task.Delay(milisecondsAfter);

        SceneController.ReloadScene();
    }
}