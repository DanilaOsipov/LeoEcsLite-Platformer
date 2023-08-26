using UnityEngine;

namespace Services.Implemented
{
    public class UnityTimeService : ITimeService
    {
        public float DeltaTime => Time.deltaTime;

        public float FixedDeltaTime => Time.fixedDeltaTime;
    }
}