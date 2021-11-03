
namespace Scripts.Events
{
    public class PlayerTakeDamageEvent
    {
        public PlayerController Player { get; set; }

        public PlayerTakeDamageEvent(PlayerController player)
        {
            Player = player;
        }
    }
}
