using System;

public interface IGameOverMenuPresenter : IDisposable
{
    void Dispose();
    void GoToMenu();
    void PlayAgain();
}
