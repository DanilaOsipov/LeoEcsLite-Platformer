namespace Services
{
    public interface ITimeService : IService
    {
        float DeltaTime { get; }
        float FixedDeltaTime { get; }
        void SetTimeScale(float value);
    }
}