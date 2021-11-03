using Scripts.Events;
using SuperMaxim.Messaging;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    private void Awake()
    {
        Messenger.Default.Subscribe<ScoreChangedEvent>(UpdateScore);
    }

    private void OnDestroy()
    {
        Messenger.Default.Unsubscribe<ScoreChangedEvent>(UpdateScore);
    }

    public void UpdateScore(ScoreChangedEvent scoreChangedEvent)
    {
        scoreText.text = scoreChangedEvent.CurrentScore.ToString();
    }
}