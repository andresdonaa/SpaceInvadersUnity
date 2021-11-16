using Scripts.Events;
using SuperMaxim.Messaging;
using UnityEngine;

public class EnemyAnimatorController : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();

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
        animator.enabled = false; //to show die sprite
    }
}