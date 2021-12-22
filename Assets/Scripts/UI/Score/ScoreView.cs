using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour, IScoreView
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text hiscoreText;

    private IScorePresenter scorePresenter;

    private void Start()
    {
        scorePresenter = new ScorePresenter(this);
    }

    private void OnDestroy()
    {
        scorePresenter.Unsubscribe();
    }

    public void SetHiscoreText(string value)
    {
        hiscoreText.text = value;
    }

    public void SetScoreText(string value)
    {
        scoreText.text = value;
    }

    //private void Awake()
    //{
    //    Messenger.Default.Subscribe<ScoreChangedEvent>(UpdateScore);
    //    Messenger.Default.Subscribe<HiscoreChangedEvent>(UpdateHiscore);

    //    SetHiscoreText(ScoreController.GetHiscore().ToString());
    //}

    //private void OnDestroy()
    //{
    //    Messenger.Default.Unsubscribe<ScoreChangedEvent>(UpdateScore);
    //    Messenger.Default.Subscribe<HiscoreChangedEvent>(UpdateHiscore);
    //}

    //private void SetHiscoreText(string value)
    //{
    //    hiscoreText.text = value;
    //}

    //private void SetScoreText(string value)
    //{
    //    scoreText.text = value;
    //}

    //private void UpdateHiscore(HiscoreChangedEvent hiscoreChangedEvent)
    //{
    //    SetHiscoreText(hiscoreChangedEvent.CurrentHiscore.ToString());
    //}

    //private void UpdateScore(ScoreChangedEvent scoreChangedEvent)
    //{
    //    SetScoreText(scoreChangedEvent.CurrentScore.ToString());
    //}
}