public interface IScoreView
{
    void SetHiscoreText(string text);
    void SetScoreText(string text);
    void Configure(ScoreViewModel scoreViewModel, IScorePresenter scorePresenter);
}