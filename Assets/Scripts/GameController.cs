using Scripts.Events;
using SuperMaxim.Messaging;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameRules gameRules;

    private Score score;
    private int lives;

    private void Awake()
    {
        score = new Score();
        lives = gameRules.lives;

        Subscribe();
    }

    private void OnDestroy()
    {
        Unsubscribe();
    }

    private void Subscribe()
    {
        Messenger.Default.Subscribe<EnemyDestroyEvent>(OnEnemyDestroy);
        Messenger.Default.Subscribe<PlayerTakeDamageEvent>(OnPlayerReceiveDamage);
        Messenger.Default.Subscribe<PlayerDieEvent>(OnPlayerDie);
        Messenger.Default.Subscribe<PlayerCollisionWithEnemyEvent>(OnPlayerCollisionWithEnemy);
        Messenger.Default.Subscribe<GameOverEvent>(OnGameOver);
        Messenger.Default.Subscribe<WaveRespawnEvent>(OnWaveRespawn);
    }

    private void Unsubscribe()
    {
        Messenger.Default.Unsubscribe<PlayerTakeDamageEvent>(OnPlayerReceiveDamage);
        Messenger.Default.Unsubscribe<PlayerDieEvent>(OnPlayerDie);
        Messenger.Default.Unsubscribe<EnemyDestroyEvent>(OnEnemyDestroy);
        Messenger.Default.Unsubscribe<PlayerCollisionWithEnemyEvent>(OnPlayerCollisionWithEnemy);
        Messenger.Default.Unsubscribe<GameOverEvent>(OnGameOver);
        Messenger.Default.Unsubscribe<WaveRespawnEvent>(OnWaveRespawn);
    }

    private void OnPlayerCollisionWithEnemy(PlayerCollisionWithEnemyEvent playerCollisionWithEnemyEvent)
    {
        Messenger.Default.Publish(new GameOverEvent());
    }

    private void OnPlayerReceiveDamage(PlayerTakeDamageEvent playerTakeDamageEvent)
    {
        //probably do nothing here...
    }

    private void OnPlayerDie(PlayerDieEvent playerDieEvent)
    {
        lives--;
        if (lives == 0)
        {
            Messenger.Default.Publish(new GameOverEvent());
        }
    }

    private void OnEnemyDestroy(EnemyDestroyEvent enemyDestroyEvent)
    {
        score.AddScore(enemyDestroyEvent.Enemy.Score);
    }

    private void OnGameOver(GameOverEvent gameOverEvent)
    {
        Debug.Log("Game Over!");
        Invoke("RestartGame", 1f);
    }

    private void RestartGame()
    {
        SceneController.ReloadScene();
    }

    private void OnWaveRespawn(WaveRespawnEvent waveRespawnEvent)
    {
        Messenger.Default.Publish(new IncreaseDifficultyEvent(gameRules.increaseDifficultyFactor));
    }
}