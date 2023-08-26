using Common;
using Contexts.Level.ECS.Component;
using Contexts.Level.ECS.View;
using LeoEcsPhysics;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Contexts.Level.ECS.System
{
    public class CollisionEnterCheckSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<OnCollisionEnterEvent>> _filter = ApplicationConstants.ECS_EVENTS_WORLD_NAME;
        private readonly EcsPoolInject<OnCollisionEnterEvent> _collisions = ApplicationConstants.ECS_EVENTS_WORLD_NAME;
        private readonly EcsPoolInject<Owner> _owners = ApplicationConstants.ECS_EVENTS_WORLD_NAME;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                var evt = _collisions.Value.Get(entity);
                if (evt.senderGameObject.TryGetComponent<IEntityView>(out var view))
                {
                    ref var owner = ref _owners.Value.Add(entity);
                    owner.Value = view.EntityWithWorld;
                }
            }
        }
    }
}