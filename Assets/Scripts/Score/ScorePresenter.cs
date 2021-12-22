using Scripts.Events;
using SuperMaxim.Messaging;

public class ScorePresenter : IScorePresenter
{
    private IScoreView scoreView;
    private ScoreModel scoreModel;
    private IDataSaver dataSaver;

    public ScorePresenter(IScoreView scoreView)
    {
        Subscribe();

        dataSaver = ServiceLocator.Instance.GetService<IDataSaver>();
        scoreModel = new ScoreModel();
        scoreModel.Hiscore = GetHiscore();

        this.scoreView = scoreView;
        this.scoreView.SetHiscoreText(GetHiscore().ToString());
    }

    public void Subscribe()
    {
        Messenger.Default.Subscribe<EnemyDestroyEvent>(OnEnemyDestroy);
    }

    public void Unsubscribe()
    {
        Messenger.Default.Unsubscribe<EnemyDestroyEvent>(OnEnemyDestroy);
    }

    private void OnEnemyDestroy(EnemyDestroyEvent enemyDestroyEvent)
    {
        AddScore(enemyDestroyEvent.Enemy.Score);
    }

    private void UpdateHiscore(int hiscore)
    {
        scoreView.SetHiscoreText(hiscore.ToString());
    }

    private void UpdateScore(int score)
    {
        scoreView.SetScoreText(score.ToString());
    }
    public void AddScore(int score)
    {
        scoreModel.CurrentScore += score;

        UpdateScore(scoreModel.CurrentScore);

        SetHiscore(scoreModel.CurrentScore);
    }

    public void SetHiscore(int currentScore)
    {
        if (currentScore > scoreModel.Hiscore)
        {
            scoreModel.Hiscore = currentScore;

            dataSaver.SetInt(DataSaverKeys.HISCORE, scoreModel.Hiscore);

            UpdateHiscore(scoreModel.Hiscore);
        }
    }

    public int GetHiscore()
    {
        return dataSaver.GetInt(DataSaverKeys.HISCORE);
    }
}