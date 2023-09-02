using LeoEcsPhysics;
using UnityEngine;

namespace Contexts.Level.ECS.System
{
    public class CollisionExitCheckSystem : PhysicsCheckSystem<OnCollisionExitEvent>
    {
        protected override GameObject GetSender(OnCollisionExitEvent evt) => evt.senderGameObject;
    }
}