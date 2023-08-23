using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Services;
using Common;
using Contexts.Level.ECS.Event;

namespace Contexts.Level.ECS.System
{
    public class AxisInputCheckSystem : IEcsRunSystem
    {
        private readonly EcsWorldInject _eventsWorld = ApplicationConstants.ECS_EVENTS_WORLD_NAME;
        private readonly EcsCustomInject<IInputService> _inputService;

        public void Run(IEcsSystems systems)
        {
            var axis = _inputService.Value.Axis;

            if (axis.x != 0 || axis.y != 0)
            {
                var entity = _eventsWorld.Value.NewEntity();
                var pool = _eventsWorld.Value.GetPool<AxisInputEvent>();
                ref var evt = ref pool.Add(entity);
                evt.Axis = axis;
            }
        }
    }
}