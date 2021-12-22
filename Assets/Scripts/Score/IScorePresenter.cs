public interface IScorePresenter
{
    void AddScore(int score);
    void SetHiscore(int currentScore);
    int GetHiscore();
    void Subscribe();
    void Unsubscribe();
}