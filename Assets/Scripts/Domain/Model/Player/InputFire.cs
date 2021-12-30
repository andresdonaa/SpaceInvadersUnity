using Scripts.Events;
using SuperMaxim.Messaging;
using UnityEngine;

public class InputFire : MonoBehaviour
{
    private IFireable projectile;

    private void Awake()
    {
        projectile = GetComponent<IFireable>();

        if (projectile != null)
            Messenger.Default.Subscribe<FireButtonPressedEvent>(OnFireButtonPressed);
    }

    private void OnDestroy()
    {
        Messenger.Default.Unsubscribe<FireButtonPressedEvent>(OnFireButtonPressed);
    }

    private void OnFireButtonPressed(FireButtonPressedEvent fireButtonPressedEvent)
    {
        projectile.Fire();
    }
}