using Contexts.Level.ECS.Component;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Common;
using Contexts.Level.ECS.Event;

namespace Contexts.Level.ECS.System
{
    public class InputMovementSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<InputMovement, Position, Speed>> _movementFilter = default;
        private readonly EcsPoolInject<Position> _positions = default;
        private readonly EcsPoolInject<Speed> _speeds = default;
        private readonly EcsPoolInject<PositionChangedMarker> _positionChangedMarkers = default;

        private readonly EcsFilterInject<Inc<AxisInputEvent>> _axisFilter = ApplicationConstants.ECS_EVENTS_WORLD_NAME;
        private readonly EcsPoolInject<AxisInputEvent> _axisInputs = ApplicationConstants.ECS_EVENTS_WORLD_NAME;

        public void Run(IEcsSystems systems)
        {
            foreach (var axisEntity in _axisFilter.Value)
            {
                var axis = _axisInputs.Value.Get(axisEntity).Axis;

                foreach (var movementEntity in _movementFilter.Value)
                {
                    ref var position = ref _positions.Value.Get(movementEntity);
                    var speed = _speeds.Value.Get(movementEntity);
                    position.Value.x += axis.x * speed.Value;

                    if (!_positionChangedMarkers.Value.Has(movementEntity))
                    {
                        _positionChangedMarkers.Value.Add(movementEntity);
                    }
                }
            }
        }
    }
}