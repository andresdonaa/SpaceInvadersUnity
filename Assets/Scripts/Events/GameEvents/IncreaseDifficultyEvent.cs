namespace Scripts.Events
{
    public class IncreaseDifficultyEvent
    {
        public float IncreaseDifficultyFactor { get; private set; }

        public IncreaseDifficultyEvent(float increaseDifficultyFactor)
        {
            IncreaseDifficultyFactor = increaseDifficultyFactor;
        }
    }
}