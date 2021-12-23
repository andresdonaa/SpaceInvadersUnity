using Scripts.Events;
using SuperMaxim.Messaging;
using UnityEngine;

public class PlayerInputController : IInput
{
    private const string AXIS_HORIZONTAL = "Horizontal";
    private const string BTN_FIRE_1 = "Fire1";

    private bool fireButton;

    public float Horizontal { get; private set; }

    public void Tick()
    {
        Horizontal = Input.GetAxis(AXIS_HORIZONTAL);
        fireButton = Input.GetButtonDown(BTN_FIRE_1);
        if (fireButton)
        {
            Messenger.Default.Publish(new FireButtonPressedEvent());
        }
    }
}