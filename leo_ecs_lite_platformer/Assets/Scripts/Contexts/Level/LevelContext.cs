using Common;
using Contexts.Common;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.ExtendedSystems;
using Leopotam.EcsLite.UnityEditor;
using LeoEcsPhysics;
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

            EcsPhysicsEvents.ecsWorld = eventsWorld;

            var inputService = GetService<IInputService>();
            var timeService = GetService<ITimeService>();

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
                .Add(new JumpInputCheckSystem())
#if UNITY_EDITOR
                .Add(new EcsWorldDebugSystem())
                .Add(new EcsWorldDebugSystem(ApplicationConstants.ECS_EVENTS_WORLD_NAME))
#endif
                .Inject(inputService)
                .Init();

            _fixedUpdateSystems = new EcsSystems(defaultWorld);
            _fixedUpdateSystems
                .AddWorld(eventsWorld, ApplicationConstants.ECS_EVENTS_WORLD_NAME)
                .Add(new CollisionEnterCheckSystem())
                .Add(new GroundEnterCheckSystem())
                .Add(new CollisionStayCheckSystem())
                .Add(new GroundStayCheckSystem())
                .Add(new CollisionExitCheckSystem())
                .Add(new GroundExitCheckSystem())
                .Add(new TriggerEnterCheckSystem())
                .Add(new LevelExitCheckSystem())
                .Add(new ViewPositionGetSystem())
                .Add(new InputMovementSystem())
                .Add(new InputJumpSystem())
                .Add(new ViewPositionSetSystem())
                .DelHerePhysics(ApplicationConstants.ECS_EVENTS_WORLD_NAME)
                .DelHere<JumpInputEvent>(ApplicationConstants.ECS_EVENTS_WORLD_NAME)
                .DelHere<Owner>(ApplicationConstants.ECS_EVENTS_WORLD_NAME)
                .DelHere<PositionChangedMarker>()
                .Inject(timeService)
                .Init();
        }

        private void Update() => _updateSystems.Run();

        private void FixedUpdate() => _fixedUpdateSystems.Run();
    }
}