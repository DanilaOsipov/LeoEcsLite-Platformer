using Contexts.Level.ECS.Component;
using LeoEcsPhysics;
using Leopotam.EcsLite;
using UnityEngine;

namespace Contexts.Level.ECS.System
{
    public class GroundStayCheckSystem : GroundCheckSystem<OnCollisionStayEvent>
    {
        protected override Collider GetCollider(OnCollisionStayEvent evt) => evt.collider;

        protected override void ProcessEntity(int entity, EcsPool<Grounded> groundeds)
        {
            if (!groundeds.Has(entity))
            {
                groundeds.Add(entity);
            }
        }
    }
}