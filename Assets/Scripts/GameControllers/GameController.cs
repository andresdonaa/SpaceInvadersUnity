using Scripts.Events;
using SuperMaxim.Messaging;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameRules gameRules;

    private ScoreController score;
    private DifficultyController difficulty;    
    private LivesController lives;

    private void Awake()
    {
        score = new ScoreController();
        difficulty = new DifficultyController(gameRules.increaseDifficultyFactor);        
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
    }

    private void Unsubscribe()
    {
        Messenger.Default.Unsubscribe<EnemyDestroyEvent>(OnEnemyDestroy);        
    }

    private void OnEnemyDestroy(EnemyDestroyEvent enemyDestroyEvent)
    {
        score.AddScore(enemyDestroyEvent.Enemy.Score);
    }
}

// TO DO:
// PlayerPrefs Adapter
// Sólo los enemigos de la primer fila pueden disparar
// Límites de wave para distintos aspect ratio
// Musica
// Icono para build
// Compatibilidad con mando
// Unit testing

// BUGS

// IMPROVEMENTS
// Object pooling (enemies, player bullets, enemy bullets)