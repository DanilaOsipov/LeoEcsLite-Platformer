using Leopotam.EcsLite;
using UnityEngine;

namespace Contexts.Level.ECS.View
{
    public class EntityView : MonoBehaviour, IEntityView
    {
        public EcsPackedEntityWithWorld EntityWithWorld { get; private set; }

        public bool IsInitialized { get; private set; }

        public void Initialize(EcsPackedEntityWithWorld entityWithWorld)
        {
            if (IsInitialized) return;
            EntityWithWorld = entityWithWorld;
            IsInitialized = true;
        }
    }
}