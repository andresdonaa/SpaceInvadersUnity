using Scripts.Events;
using SuperMaxim.Messaging;
using UnityEngine;

public class SideBoundaries : MonoBehaviour
{
    private bool alreadyTouchedBoundary = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
        if (enemy != null && !alreadyTouchedBoundary)
        {
            alreadyTouchedBoundary = true;            
            Messenger.Default.Publish(new EnemyTouchedSideBoundaryEvent());

            Invoke(nameof(ResetTouchBoundary), 1f);
        }
    }

    private void ResetTouchBoundary()
    {
        alreadyTouchedBoundary = false;
    }
}