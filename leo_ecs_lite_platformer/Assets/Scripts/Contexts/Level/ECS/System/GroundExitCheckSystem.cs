using Contexts.Level.ECS.Component;
using LeoEcsPhysics;
using Leopotam.EcsLite;
using UnityEngine;

namespace Contexts.Level.ECS.System
{
    public class GroundExitCheckSystem : GroundCheckSystem<OnCollisionExitEvent>
    {
        protected override Collider GetCollider(OnCollisionExitEvent evt) => evt.collider;

        protected override void ProcessEntity(int entity, EcsPool<Grounded> groundeds)
        {
            if (groundeds.Has(entity))
            {
                groundeds.Del(entity);
            }
        }
    }
}