using LeoEcsPhysics;
using UnityEngine;

namespace Contexts.Level.ECS.System
{
    public class TriggerEnterCheckSystem : PhysicsCheckSystem<OnTriggerEnterEvent>
    {
        protected override GameObject GetSender(OnTriggerEnterEvent evt) => evt.senderGameObject;
    }
}