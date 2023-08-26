using Contexts.Level.ECS.Component;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Contexts.Level.ECS.System
{
    public class ViewPositionGetSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<PositionListener, Position>> _filter = default;
        private readonly EcsPoolInject<Position> _positions = default;
        private readonly EcsPoolInject<PositionListener> _listeners = default;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                ref var position = ref _positions.Value.Get(entity);
                position.Value = _listeners.Value.Get(entity).Value.CurrentPosition;
            }
        }
    }
}