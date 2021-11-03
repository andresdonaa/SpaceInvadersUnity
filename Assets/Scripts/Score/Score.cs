using Scripts.Events;
using SuperMaxim.Messaging;

public class Score
{
    private int currentScore;

    public int CurrentScore { get => currentScore; private set => currentScore = value; }

    public void AddScore(int value)
    {
        currentScore += value;
        Messenger.Default.Publish(new ScoreChangedEvent(currentScore));        
    }
}