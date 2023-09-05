using UnityEngine;

namespace Services.Implemented
{
    public class UnityTimeService : ITimeService
    {
        public float DeltaTime => Time.deltaTime;

        public float FixedDeltaTime => Time.fixedDeltaTime;

        public void SetTimeScale(float value) => Time.timeScale = value;
    }
}