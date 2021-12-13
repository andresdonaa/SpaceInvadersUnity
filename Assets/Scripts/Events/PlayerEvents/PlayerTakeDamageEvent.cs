
namespace Scripts.Events
{
    public class PlayerTakeDamageEvent
    {
        public PlayerController Player { get; private set; }

        public PlayerTakeDamageEvent(PlayerController player)
        {
            Player = player;
        }
    }
}
