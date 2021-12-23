using UnityEngine.UI;
using Scripts.Events;
using SuperMaxim.Messaging;

public class HealthbarPlayer : HealthbarBase
{    
    private void Awake()
    {
        slider = GetComponent<Slider>();        
        Messenger.Default.Subscribe<PlayerTakeDamageEvent>(OnPlayerTakeDamage);
        Messenger.Default.Subscribe<PlayerRespawnEvent>(OnPlayerRespawn);        
    }

    private void OnPlayerRespawn(PlayerRespawnEvent playerRespawnEvent)
    {
        UpdateHealth(playerRespawnEvent.Player.Health);
    }

    private void OnPlayerTakeDamage(PlayerTakeDamageEvent playerTakeDamageEvent)
    {
        UpdateHealth(playerTakeDamageEvent.Player.Health);
    }

    private void OnDestroy()
    {
        Messenger.Default.Unsubscribe<PlayerTakeDamageEvent>(OnPlayerTakeDamage);
        Messenger.Default.Unsubscribe<PlayerRespawnEvent>(OnPlayerRespawn);
    }
}