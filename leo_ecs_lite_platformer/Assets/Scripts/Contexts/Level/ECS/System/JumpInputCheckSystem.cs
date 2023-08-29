using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Services;
using Common;
using Contexts.Level.ECS.Event;

namespace Contexts.Level.ECS.System
{
    public class JumpInputCheckSystem : IEcsRunSystem
    {
        private readonly EcsWorldInject _eventsWorld = ApplicationConstants.ECS_EVENTS_WORLD_NAME;
        private readonly EcsPoolInject<JumpInputEvent> _jumpInputs = ApplicationConstants.ECS_EVENTS_WORLD_NAME;

        private readonly EcsCustomInject<IInputService> _inputService;

        public void Run(IEcsSystems systems)
        {
            if (_inputService.Value.JumpButtonDown)
            {
                var entity = _eventsWorld.Value.NewEntity();
                _jumpInputs.Value.Add(entity);
            }
        }
    }
}