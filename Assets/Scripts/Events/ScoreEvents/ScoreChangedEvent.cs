namespace Scripts.Events
{
    public class ScoreChangedEvent
    {
        public int CurrentScore { get; set; }

        public ScoreChangedEvent(int currentScore)
        {
            CurrentScore = currentScore;
        }
    }
}
