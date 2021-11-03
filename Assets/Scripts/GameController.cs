using Scripts.Events;
using SuperMaxim.Messaging;
using System;
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
    }
    
    private void Unsubscribe()
    {
        Messenger.Default.Unsubscribe<PlayerTakeDamageEvent>(OnPlayerReceiveDamage);
        Messenger.Default.Unsubscribe<PlayerDieEvent>(OnPlayerDie);
        Messenger.Default.Unsubscribe<EnemyDestroyEvent>(OnEnemyDestroy);
    }

    private void OnPlayerReceiveDamage(PlayerTakeDamageEvent playerTakeDamageEvent)
    {
        //probably do nothing here...
    }

    private void OnPlayerDie(PlayerDieEvent playerDieEvent)
    {
        //gameRules.lives--;
        lives--;
        if (lives == 0)
        {
            Messenger.Default.Publish(new GameOverEvent());            
            Debug.Log("Game Over!");
        }
    }

    private void OnEnemyDestroy(EnemyDestroyEvent enemyDestroyEvent)
    {
        score.AddScore(enemyDestroyEvent.Enemy.Score);
    }

}