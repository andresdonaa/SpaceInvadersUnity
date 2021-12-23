using Scripts.Events;
using SuperMaxim.Messaging;
using System;

internal class LivesController : IDisposable
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

    public void Dispose()
    {
        Messenger.Default.Unsubscribe<PlayerDieEvent>(OnPlayerDie);
    }
}