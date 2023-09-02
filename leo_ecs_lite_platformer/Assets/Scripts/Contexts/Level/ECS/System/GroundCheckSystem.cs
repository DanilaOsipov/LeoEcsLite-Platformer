using Common;
using Contexts.Level.ECS.Component;
using Leopotam.EcsLite;
using UnityEngine;

namespace Contexts.Level.ECS.System
{
    public abstract class GroundCheckSystem<TEvent> : IEcsInitSystem, IEcsRunSystem where TEvent : struct
    {
        private EcsFilter _filter;
        private EcsPool<TEvent> _events;
        private EcsPool<Owner> _owners;

        public void Init(IEcsSystems systems)
        {
            EcsWorld ecsWorld = systems.GetWorld(ApplicationConstants.ECS_EVENTS_WORLD_NAME);
            _filter = ecsWorld.Filter<Owner>().Inc<TEvent>().End();
            _events = ecsWorld.GetPool<TEvent>();
            _owners = ecsWorld.GetPool<Owner>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var evtEntity in _filter)
            {
                var evt = _events.Get(evtEntity);
                if (GetCollider(evt).CompareTag(ApplicationConstants.GROUND_TAG))
                {
                    var owner = _owners.Get(evtEntity);
                    owner.Value.Unpack(out var world, out var entity);
                    var groundeds = world.GetPool<Grounded>();
                    ProcessEntity(entity, groundeds);
                }
            }
        }

        protected abstract void ProcessEntity(int entity, EcsPool<Grounded> groundeds);

        protected abstract Collider GetCollider(TEvent evt);
    }
}