using Scripts.Events;
using SuperMaxim.Messaging;
using UnityEngine;

public class Score
{
    private int currentScore;
    private int hiscore;

    public Score()
    {
        hiscore = GetHiscore();
    }

    public void AddScore(int value)
    {
        currentScore += value;
        Messenger.Default.Publish(new ScoreChangedEvent(currentScore));

        SetHiscore(currentScore);
    }

    private void SetHiscore(int currentScore)
    {
        if (currentScore > hiscore)
        {
            hiscore = currentScore;
            PlayerPrefs.SetInt(PlayerPrefsKeys.HISCORE, hiscore);

            Messenger.Default.Publish(new HiscoreChangedEvent(hiscore));
        }
    }

    public static int GetHiscore()
    {
        return PlayerPrefs.GetInt(PlayerPrefsKeys.HISCORE);
    }
}