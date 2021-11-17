using Scripts.Events;
using SuperMaxim.Messaging;
using UnityEngine;

public class EnemyAnimatorController : MonoBehaviour
{
    private Animator animator;
    private EnemyController enemy;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        enemy = GetComponent<EnemyController>();

        Messenger.Default.Subscribe<WaveMoveStepEvent>(OnWaveMoveStep);
        Messenger.Default.Subscribe<EnemyDestroyEvent>(OnEnemyDestroy);
    }

    private void OnDestroy()
    {
        Messenger.Default.Unsubscribe<WaveMoveStepEvent>(OnWaveMoveStep);
        Messenger.Default.Unsubscribe<EnemyDestroyEvent>(OnEnemyDestroy);
    }

    private void OnWaveMoveStep(WaveMoveStepEvent waveMoveStepEvent)
    {        
        animator?.SetTrigger("AnimationStep");
    }

    private void OnEnemyDestroy(EnemyDestroyEvent enemyDestroyEvent)
    {
        if(enemyDestroyEvent.Enemy.Equals(enemy))
            animator.enabled = false; //to show die sprite
    }
}