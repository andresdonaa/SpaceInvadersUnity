using UnityEngine.UI;
using Scripts.Events;
using SuperMaxim.Messaging;

public class HealthbarPlayer : HealthbarBase
{    
    private void Awake()
    {
        slider = GetComponent<Slider>();        
        Messenger.Default.Subscribe<PlayerTakeDamageEvent>(PlayerController_OnTakeDamage);
        Messenger.Default.Subscribe<PlayerRespawnEvent>(PlayerController_OnRespawn);        
    }

    private void PlayerController_OnRespawn(PlayerRespawnEvent playerRespawnEvent)
    {
        UpdateHealth(playerRespawnEvent.Player.Health);
    }

    private void PlayerController_OnTakeDamage(PlayerTakeDamageEvent playerTakeDamageEvent)
    {
        UpdateHealth(playerTakeDamageEvent.Player.Health);
    }

    private void OnDestroy()
    {
        Messenger.Default.Unsubscribe<PlayerTakeDamageEvent>(PlayerController_OnTakeDamage);
        Messenger.Default.Unsubscribe<PlayerRespawnEvent>(PlayerController_OnRespawn);
    }
}