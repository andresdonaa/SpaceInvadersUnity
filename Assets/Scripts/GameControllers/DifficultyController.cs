using Scripts.Events;
using SuperMaxim.Messaging;

public class DifficultyController
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
}