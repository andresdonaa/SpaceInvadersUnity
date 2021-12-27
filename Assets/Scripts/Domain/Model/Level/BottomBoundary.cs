using Scripts.Events;
using SuperMaxim.Messaging;
using UnityEngine;

public class BottomBoundary : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
        if (enemy != null)
        {
            Messenger.Default.Publish(new GameOverEvent());
        }
    }
}