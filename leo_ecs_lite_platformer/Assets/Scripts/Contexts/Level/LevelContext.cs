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
using Contexts.UI.View.Implemented;

namespace Contexts.Level
{
    public class LevelContext : AplicationContext
    {
        private EcsSystems _initSystems;
        private EcsSystems _updateSystems;
        private EcsSystems _fixedUpdateSystems;

        private EcsWorld _defaultWorld;
        private EcsWorld _eventsWorld;

        private void Awake()
        {
            _defaultWorld = new EcsWorld();
            _eventsWorld = new EcsWorld();

            EcsPhysicsEvents.ecsWorld = _eventsWorld;

            var inputService = GetService<IInputService>();
            var timeService = GetService<ITimeService>();
            var uiService = GetService<IUIService>();

            _initSystems = new EcsSystems(_defaultWorld);
            _initSystems
                .AddWorld(_eventsWorld, ApplicationConstants.ECS_EVENTS_WORLD_NAME)
                .Inject()
                .ConvertScene()
                .Init();

            _updateSystems = new EcsSystems(_defaultWorld);
            _updateSystems
                .AddWorld(_eventsWorld, ApplicationConstants.ECS_EVENTS_WORLD_NAME)
                .DelHere<AxisInputEvent>(ApplicationConstants.ECS_EVENTS_WORLD_NAME)
                .Add(new AxisInputCheckSystem())
                .Add(new JumpInputCheckSystem())
#if UNITY_EDITOR
                .Add(new EcsWorldDebugSystem())
                .Add(new EcsWorldDebugSystem(ApplicationConstants.ECS_EVENTS_WORLD_NAME))
#endif
                .Inject(inputService)
                .Init();

            _fixedUpdateSystems = new EcsSystems(_defaultWorld);
            _fixedUpdateSystems
                .AddWorld(_eventsWorld, ApplicationConstants.ECS_EVENTS_WORLD_NAME)
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
                .Add(new UIPanelShowSystem<UILevelCompletedPanelView, PlayerExitLevelEvent>())
                .Add(new TimePauseSystem<PlayerExitLevelEvent>())
                .DelHerePhysics(ApplicationConstants.ECS_EVENTS_WORLD_NAME)
                .DelHere<JumpInputEvent>(ApplicationConstants.ECS_EVENTS_WORLD_NAME)
                .DelHere<PlayerExitLevelEvent>(ApplicationConstants.ECS_EVENTS_WORLD_NAME)
                .DelHere<Owner>(ApplicationConstants.ECS_EVENTS_WORLD_NAME)
                .DelHere<PositionChangedMarker>()
                .Inject(timeService, uiService)
                .Init();
        }

        private void Update() => _updateSystems.Run();

        private void FixedUpdate() => _fixedUpdateSystems.Run();

        private void OnDestroy()
        {
            var timeService = GetService<ITimeService>();
            timeService.SetTimeScale(1.0f);

            EcsPhysicsEvents.ecsWorld = null;

            _initSystems?.Destroy();
            _updateSystems?.Destroy();
            _fixedUpdateSystems?.Destroy();

            _initSystems = null;
            _updateSystems = null;
            _fixedUpdateSystems = null;

            _defaultWorld?.Destroy();
            _eventsWorld?.Destroy();

            _defaultWorld = null;
            _eventsWorld = null;
        }
    }
}