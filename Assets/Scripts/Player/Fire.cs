using Scripts.Events;
using SuperMaxim.Messaging;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private IFireable projectile;

    private void Awake()
    {
        projectile = GetComponent<IFireable>();

        Messenger.Default.Subscribe<FireButtonPressedEvent>(OnFireButtonPressed);
    }

    private void OnDestroy()
    {
        Messenger.Default.Unsubscribe<FireButtonPressedEvent>(OnFireButtonPressed);
    }

    private void OnFireButtonPressed(FireButtonPressedEvent fireButtonPressedEvent)
    {
        if (projectile != null)
        {
            projectile.Fire();
        }
    }
}