namespace Scripts.Events
{
    public class PlayerRespawnEvent
    {
        public PlayerController Player { get; set; }

        public PlayerRespawnEvent(PlayerController player)
        {
            Player = player;
        }
    }
}
