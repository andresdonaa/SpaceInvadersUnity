using Scripts.Events;
using SuperMaxim.Messaging;
using System.Collections;
using UnityEngine;

public class EnemyWaveMovement : MonoBehaviour
{
    [SerializeField] private float waveStepDown = 1f;

    [Range(0.1f, 5f)]
    [SerializeField] private float waveDelaySpeed = 1f;

    [Range(0.1f, 2f)]
    [SerializeField] private float waveStepRight = 1f;

    private float waveSpeedModifier = 1f;
    private bool canMove = true;
    private bool moveRight = true;

    private void Awake()
    {
        Messenger.Default.Subscribe<EnemyTouchedSideBoundaryEvent>(OnEnemyTouchSideBoundary);
        Messenger.Default.Subscribe<WaveRespawnEvent>(OnWaveRespawn);
        Messenger.Default.Subscribe<IncreaseDifficultyEvent>(OnIncreaseDifficulty);
        Messenger.Default.Subscribe<GameOverEvent>(OnGameOverEvent);
    }

    private void OnDestroy()
    {
        Messenger.Default.Unsubscribe<EnemyTouchedSideBoundaryEvent>(OnEnemyTouchSideBoundary);
        Messenger.Default.Unsubscribe<WaveRespawnEvent>(OnWaveRespawn);
        Messenger.Default.Unsubscribe<IncreaseDifficultyEvent>(OnIncreaseDifficulty);
        Messenger.Default.Unsubscribe<GameOverEvent>(OnGameOverEvent);
    }

    private void Start()
    {
        StartCoroutine(DoStep());
    }

    private IEnumerator DoStep()
    {
        while (canMove)
        {
            Vector2 direction = moveRight ? Vector2.right : Vector2.left;
            transform.Translate(direction * waveStepRight);
            Messenger.Default.Publish(new WaveMoveStepEvent());

            yield return new WaitForSeconds(waveDelaySpeed / waveSpeedModifier);
        }
    }

    private void OnGameOverEvent(GameOverEvent gameOverEvent)
    {
        canMove = false;
    }

    private void OnEnemyTouchSideBoundary(EnemyTouchedSideBoundaryEvent enemyTouchedSideBoundaryEvent)
    {        
        moveRight = !moveRight;
        transform.Translate(Vector2.down * waveStepDown);     
    }

    private void OnWaveRespawn(WaveRespawnEvent waveRespawnEvent)
    {
        moveRight = true;
    }

    private void OnIncreaseDifficulty(IncreaseDifficultyEvent increaseDifficultyEvent)
    {
        waveSpeedModifier = waveSpeedModifier * increaseDifficultyEvent.IncreaseDifficultyFactor;
    }
}