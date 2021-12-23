using Scripts.Events;
using SuperMaxim.Messaging;
using System;

public class DifficultyController : IDisposable
{
    private readonly float increaseDifficultyFactor;

    public DifficultyController(float increaseDifficultyFactor)
    {
        this.increaseDifficultyFactor = increaseDifficultyFactor;

        Subscribe();
    }

    private void Subscribe()
    {
        Messenger.Default.Subscribe<WaveRespawnEvent>(OnWaveRespawn);
    }

    private void OnWaveRespawn(WaveRespawnEvent waveRespawnEvent)
    {
        Messenger.Default.Publish(new IncreaseDifficultyEvent(increaseDifficultyFactor));
    }

    public void Dispose()
    {
        Messenger.Default.Unsubscribe<WaveRespawnEvent>(OnWaveRespawn);
    }
}