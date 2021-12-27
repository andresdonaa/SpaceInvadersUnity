namespace Scripts.Services
{
    public interface IInput
    {
        float Horizontal { get; }

        void Tick();
    }
}
