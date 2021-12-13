using Scripts.Events;
using SuperMaxim.Messaging;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameRules gameRules;

    private ScoreController score;
    private DifficultyController difficulty;
    private GameOverController gameOver;
    private LivesController lives;

    private void Awake()
    {
        score = new ScoreController();
        difficulty = new DifficultyController(gameRules.increaseDifficultyFactor);
        gameOver = new GameOverController();
        lives = new LivesController(gameRules.lives);

        Subscribe();
    }

    private void OnDestroy()
    {
        Unsubscribe();
    }

    private void Subscribe()
    {
        Messenger.Default.Subscribe<EnemyDestroyEvent>(OnEnemyDestroy);
        Messenger.Default.Subscribe<PlayerCollisionWithEnemyEvent>(OnPlayerCollisionWithEnemy);
    }

    private void Unsubscribe()
    {
        Messenger.Default.Unsubscribe<EnemyDestroyEvent>(OnEnemyDestroy);
        Messenger.Default.Unsubscribe<PlayerCollisionWithEnemyEvent>(OnPlayerCollisionWithEnemy);
    }

    private void OnPlayerCollisionWithEnemy(PlayerCollisionWithEnemyEvent playerCollisionWithEnemyEvent)
    {
        Messenger.Default.Publish(new GameOverEvent());
    }

    private void OnEnemyDestroy(EnemyDestroyEvent enemyDestroyEvent)
    {
        score.AddScore(enemyDestroyEvent.Enemy.Score);
    }
}

// TO DO:
// Game over menu
// Sólo los enemigos de la primer fila pueden disparar
// Límites de wave para distintos aspect ratio
// Musica
// Icono para build
// Compatibilidad con mando
// Unit testing

// BUGS

// IMPROVEMENTS
// Object pooling (enemies, player bullets, enemy bullets)