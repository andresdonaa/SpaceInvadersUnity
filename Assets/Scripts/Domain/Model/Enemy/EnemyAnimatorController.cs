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
    }

    private void OnDestroy()
    {
        Messenger.Default.Unsubscribe<WaveMoveStepEvent>(OnWaveMoveStep);
    }

    private void OnWaveMoveStep(WaveMoveStepEvent waveMoveStepEvent)
    {
        animator?.SetTrigger("AnimationStep");
    }
}