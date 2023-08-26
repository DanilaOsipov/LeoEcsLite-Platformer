using Leopotam.EcsLite;

namespace Contexts.Level.ECS.View
{
    public interface IEntityView
    {
        EcsPackedEntityWithWorld EntityWithWorld { get; }
        bool IsInitialized { get; }
        void Initialize(EcsPackedEntityWithWorld entityWithWorld);
    }
}