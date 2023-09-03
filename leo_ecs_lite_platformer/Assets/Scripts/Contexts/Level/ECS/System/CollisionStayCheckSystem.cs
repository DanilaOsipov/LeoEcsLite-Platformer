using LeoEcsPhysics;
using UnityEngine;

namespace Contexts.Level.ECS.System
{
    public class CollisionStayCheckSystem : PhysicsCheckSystem<OnCollisionStayEvent>
    {
        protected override GameObject GetSender(OnCollisionStayEvent evt) => evt.senderGameObject;
    }
}