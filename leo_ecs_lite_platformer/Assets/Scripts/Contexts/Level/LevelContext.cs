using Common;
using Contexts.Common;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.ExtendedSystems;
using AB_Utility.FromSceneToEntityConverter;
using Contexts.Level.ECS.System;
using Services;
using Contexts.Level.ECS.Event;
using Contexts.Level.ECS.Component;

namespace Contexts.Level
{
    public class LevelContext : AplicationContext
    {
        private EcsSystems _updateSystems;
        private EcsSystems _fixedUpdateSystems;

        private void Awake()
        {
            var defaultWorld = new EcsWorld();
            var eventsWorld = new EcsWorld();

            var inputService = GetService<IInputService>();

            var initSystems = new EcsSystems(defaultWorld);
            initSystems
                .AddWorld(eventsWorld, ApplicationConstants.ECS_EVENTS_WORLD_NAME)
                .Inject()
                .ConvertScene()
                .Init();

            _updateSystems = new EcsSystems(defaultWorld);
            _updateSystems
                .AddWorld(eventsWorld, ApplicationConstants.ECS_EVENTS_WORLD_NAME)
                .DelHere<AxisInputEvent>(ApplicationConstants.ECS_EVENTS_WORLD_NAME)
                .Add(new AxisInputCheckSystem())
                .Inject(inputService)
                .Init();

            _fixedUpdateSystems = new EcsSystems(defaultWorld);
            _fixedUpdateSystems
                .AddWorld(eventsWorld, ApplicationConstants.ECS_EVENTS_WORLD_NAME)
                .DelHere<PositionChangedMarker>()
                .Add(new InputMovementSystem())
                .Add(new ViewPositionSetSystem())
                .Inject()
                .Init();
        }

        private void Update() => _updateSystems.Run();

        private void FixedUpdate() => _fixedUpdateSystems.Run();
    }
}