using Common;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Services;

namespace Contexts.Level.ECS.System
{
    public class TimePauseSystem<TEvent> : IEcsInitSystem, IEcsRunSystem where TEvent : struct
    {
        private readonly EcsCustomInject<ITimeService> _timeService;

        private EcsFilter _filter;

        public void Init(IEcsSystems systems)
        {
            EcsWorld ecsWorld = systems.GetWorld(ApplicationConstants.ECS_EVENTS_WORLD_NAME);
            _filter = ecsWorld.Filter<TEvent>().End();
        }

        public void Run(IEcsSystems systems)
        {
            if (_filter.GetEntitiesCount() > 0)
            {
                _timeService.Value.SetTimeScale(0.0f);
            }
        }
    }
}