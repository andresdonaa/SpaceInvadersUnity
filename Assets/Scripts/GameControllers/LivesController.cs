using Scripts.Events;
using SuperMaxim.Messaging;

internal class LivesController
{
    private int lives;

    public LivesController(int lives)
    {
        this.lives = lives;

        Subscribe();
    }

    private void Subscribe()
    {
        Messenger.Default.Subscribe<PlayerDieEvent>(OnPlayerDie);
    }

    private void OnPlayerDie(PlayerDieEvent playerDieEvent)
    {
        lives--;
        if (lives == 0)
        {
            Messenger.Default.Publish(new GameOverEvent());
        }
    }
}