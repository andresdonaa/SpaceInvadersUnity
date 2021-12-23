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
}