using SuperMaxim.Messaging;
using Scripts.Events;
using System.Collections;
using UnityEngine;
using System;

public class WaveMovement : MonoBehaviour
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
    }

    private void OnDestroy()
    {
        Messenger.Default.Unsubscribe<EnemyTouchedSideBoundaryEvent>(OnEnemyTouchSideBoundary);
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

    private void OnEnemyTouchSideBoundary(EnemyTouchedSideBoundaryEvent enemyTouchedSideBoundaryEvent)
    {
        moveRight = !moveRight;
        transform.Translate(Vector2.down * waveStepDown);
    }
}