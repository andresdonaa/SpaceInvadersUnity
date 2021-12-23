namespace Scripts.Events
{
    public class ScoreChangedEvent
    {
        public int CurrentScore { get; private set; }

        public ScoreChangedEvent(int currentScore)
        {
            CurrentScore = currentScore;
        }
    }

    public class HiscoreChangedEvent
    {
        public int CurrentHiscore { get; private set; }

        public HiscoreChangedEvent(int currentHiscore)
        {
            CurrentHiscore = currentHiscore;
        }
    }
}
