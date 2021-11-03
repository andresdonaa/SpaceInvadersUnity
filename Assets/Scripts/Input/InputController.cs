using Scripts.Events;
using SuperMaxim.Messaging;
using UnityEngine;

public class InputController
{
    public float Horizontal { get; private set; }
    public bool OnFireButton { get; private set; }

    public void Tick()
    {
        Horizontal = Input.GetAxis("Horizontal");
        OnFireButton = Input.GetButtonDown("Fire1");
        if (OnFireButton)
        {
            Messenger.Default.Publish(new FireButtonPressedEvent());
        }
    }
}