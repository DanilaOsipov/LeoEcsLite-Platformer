using Contexts.Level.ECS.Component;
using LeoEcsPhysics;
using Leopotam.EcsLite;
using UnityEngine;

namespace Contexts.Level.ECS.System
{
    public class GroundEnterCheckSystem : GroundCheckSystem<OnCollisionEnterEvent>
    {
        protected override Collider GetCollider(OnCollisionEnterEvent evt) => evt.collider;

        protected override void ProcessEntity(int entity, EcsPool<Grounded> groundeds)
        {
            if (!groundeds.Has(entity))
            {
                groundeds.Add(entity);
            }
        }
    }
}