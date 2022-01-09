namespace Scripts.Services
{
    public interface IShipInput
    {
        float Horizontal { get; }

        void Tick();
    }
}
