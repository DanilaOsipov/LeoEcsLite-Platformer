using LeoEcsPhysics;
using UnityEngine;

namespace Contexts.Level.ECS.System
{
    public class CollisionEnterCheckSystem : PhysicsCheckSystem<OnCollisionEnterEvent>
    {
        protected override GameObject GetSender(OnCollisionEnterEvent evt) => evt.senderGameObject;
    }
}