using Common;
using Contexts.Level.ECS.Component;
using Contexts.Level.ECS.View;
using Leopotam.EcsLite;
using UnityEngine;

namespace Contexts.Level.ECS.System
{
    public abstract class PhysicsCheckSystem<TEvent> : IEcsInitSystem, IEcsRunSystem where TEvent : struct
    {
        private EcsFilter _filter;
        private EcsPool<TEvent> _events;
        private EcsPool<Owner> _owners;

        public void Init(IEcsSystems systems)
        {
            EcsWorld ecsWorld = systems.GetWorld(ApplicationConstants.ECS_EVENTS_WORLD_NAME);
            _filter = ecsWorld.Filter<TEvent>().End();
            _events = ecsWorld.GetPool<TEvent>();
            _owners = ecsWorld.GetPool<Owner>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter)
            {
                var evt = _events.Get(entity);
                if (GetSender(evt).TryGetComponent<IEntityView>(out var view))
                {
                    ref var owner = ref _owners.Add(entity);
                    owner.Value = view.EntityWithWorld;
                }
            }
        }

        protected abstract GameObject GetSender(TEvent evt);
    }
}