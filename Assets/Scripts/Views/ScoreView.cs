using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour, IScoreView
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text hiscoreText;
    
    private ScoreViewModel scoreViewModel;
    private IScorePresenter scorePresenter;

    private void OnDestroy()
    {
        scorePresenter.Unsubscribe();
    }

    public void Configure(ScoreViewModel scoreViewModel, IScorePresenter scorePresenter)
    {
        this.scoreViewModel = scoreViewModel;
        this.scorePresenter = scorePresenter;
    }

    public void SetHiscoreText(string value)
    {
        hiscoreText.text = value;
    }

    public void SetScoreText(string value)
    {
        scoreText.text = value;
    }
}