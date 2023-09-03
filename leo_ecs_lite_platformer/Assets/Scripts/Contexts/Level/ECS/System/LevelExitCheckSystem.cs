using Common;
using Contexts.Level.ECS.Component;
using Contexts.Level.ECS.Event;
using Contexts.Level.ECS.View;
using LeoEcsPhysics;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Contexts.Level.ECS.System
{
    public class LevelExitCheckSystem : IEcsRunSystem
    {
        private readonly EcsWorldInject _eventsWorld = ApplicationConstants.ECS_EVENTS_WORLD_NAME;
        private readonly EcsFilterInject<Inc<Owner, OnTriggerEnterEvent>> _filter = ApplicationConstants.ECS_EVENTS_WORLD_NAME;
        private readonly EcsPoolInject<OnTriggerEnterEvent> _triggerEvents = ApplicationConstants.ECS_EVENTS_WORLD_NAME;
        private readonly EcsPoolInject<Owner> _owners = ApplicationConstants.ECS_EVENTS_WORLD_NAME;
        private readonly EcsPoolInject<PlayerExitLevelEvent> _exitEvents = ApplicationConstants.ECS_EVENTS_WORLD_NAME;

        public void Run(IEcsSystems systems)
        {
            foreach(var evtEntity in _filter.Value)
            {
                if (CheckIfEntityIsExit(evtEntity) && CheckIfPlayerOnExit(evtEntity))
                {
                    var entity = _eventsWorld.Value.NewEntity();
                    _exitEvents.Value.Add(entity);
                }
            }
        }

        private bool CheckIfPlayerOnExit(int evtEntity)
        {
            bool isPlayerOnExit = false;

            var evt = _triggerEvents.Value.Get(evtEntity);
            var view = evt.collider.GetComponentInParent<IEntityView>();
            if (view != null)
            {
                view.EntityWithWorld.Unpack(out var world, out var entity);
                var players = world.GetPool<Player>();
                isPlayerOnExit = players.Has(entity);
            }

            return isPlayerOnExit;
        }

        private bool CheckIfEntityIsExit(int evtEntity)
        {
            var owner = _owners.Value.Get(evtEntity);
            owner.Value.Unpack(out var world, out var entity);
            var exits = world.GetPool<LevelExit>();
            return exits.Has(entity);
        }
    }
}