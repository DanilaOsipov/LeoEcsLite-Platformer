using Common;
using Leopotam.EcsLite;

namespace Contexts.Level.ECS.View
{
    public interface IEntityView : IView
    {
        EcsPackedEntityWithWorld EntityWithWorld { get; }
        bool IsInitialized { get; }
        void Initialize(EcsPackedEntityWithWorld entityWithWorld);
    }
}