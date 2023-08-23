using Contexts.Level.ECS.Component;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Services;
using Common;
using Contexts.Level.ECS.Event;

namespace Contexts.Level.ECS.System
{
    public class ViewPositionGetSystem : IEcsInitSystem, IEcsRunSystem
    {
        public void Init(IEcsSystems systems)
        {
        }

        public void Run(IEcsSystems systems)
        {
        }
    }

    public class ViewPositionSetSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsWorldInject _defaultWorld = default;

        private EcsFilter _filter;
        private EcsPool<Position> _positions;
        private EcsPool<PositionListener> _listeners;

        public void Init(IEcsSystems systems)
        {
            _filter = _defaultWorld.Value.Filter<PositionChangedMarker>()
               .Inc<PositionListener>()
               .Inc<Position>()
               .End();
            _positions = _defaultWorld.Value.GetPool<Position>();
            _listeners = _defaultWorld.Value.GetPool<PositionListener>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter)
            {
                var position = _positions.Get(entity).Value;
                _listeners.Get(entity).Value.UpdatePosition(position);
            }
        }
    }

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

    public class InputMovementSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsWorldInject _defaultWorld = default;
        private readonly EcsWorldInject _eventsWorld = ApplicationConstants.ECS_EVENTS_WORLD_NAME;

        private EcsFilter _movementFilter;
        private EcsPool<Position> _positions;
        private EcsPool<Speed> _speeds;

        private EcsFilter _axisFilter;
        private EcsPool<AxisInputEvent> _axisInputs;

        private EcsPool<PositionChangedMarker> _positionChangedMarkers;

        public void Init(IEcsSystems systems)
        {
            _movementFilter = _defaultWorld.Value.Filter<InputMovement>()
                .Inc<Position>()
                .Inc<Speed>()
                .End();
            _positions = _defaultWorld.Value.GetPool<Position>();
            _speeds = _defaultWorld.Value.GetPool<Speed>();
            _positionChangedMarkers = _defaultWorld.Value.GetPool<PositionChangedMarker>();

            _axisFilter = _eventsWorld.Value.Filter<AxisInputEvent>().End();
            _axisInputs = _eventsWorld.Value.GetPool<AxisInputEvent>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var axisEntity in _axisFilter)
            {
                var axis = _axisInputs.Get(axisEntity).Axis;

                foreach (var movementEntity in _movementFilter)
                {
                    ref var position = ref _positions.Get(movementEntity);
                    var speed = _speeds.Get(movementEntity);
                    position.Value.x += axis.x * speed.Value;

                    if (!_positionChangedMarkers.Has(movementEntity))
                    {
                        _positionChangedMarkers.Add(movementEntity);
                    }
                }
            }
        }
    }
}