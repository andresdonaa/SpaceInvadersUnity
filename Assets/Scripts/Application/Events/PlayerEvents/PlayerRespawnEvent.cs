namespace Scripts.Events
{
    public class PlayerRespawnEvent
    {
        public PlayerController Player { get; private set; }

        public PlayerRespawnEvent(PlayerController player)
        {
            Player = player;
        }
    }
}
