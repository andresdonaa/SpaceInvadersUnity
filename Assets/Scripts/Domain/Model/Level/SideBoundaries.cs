using Scripts.Events;
using SuperMaxim.Messaging;
using UnityEngine;

public class SideBoundaries : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
        if (enemy != null)
        {
            Debug.Log("Enemy Touch Side Boundary");
            Messenger.Default.Publish(new EnemyTouchedSideBoundaryEvent());
        }
    }
}