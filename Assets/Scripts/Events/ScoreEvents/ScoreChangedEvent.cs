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

    public class HiscoreChangedEvent
    {
        public int CurrentHiscore { get; set; }

        public HiscoreChangedEvent(int currentHiscore)
        {
            CurrentHiscore = currentHiscore;
        }
    }
}
