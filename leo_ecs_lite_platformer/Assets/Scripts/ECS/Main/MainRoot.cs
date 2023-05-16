using ECS.Common;
using Leopotam.EcsLite;

namespace ECS.Main
{
    public class MainRoot : ECSRoot
    {
        protected override EcsSystems CreateInitSystems(EcsWorld ecsWorld)
        {
            throw new System.NotImplementedException();
        }

        protected override EcsSystems CreateUpdateSystems(EcsWorld ecsWorld)
        {
            throw new System.NotImplementedException();
        }

        protected override EcsSystems CreateFixedUpdateSystems(EcsWorld ecsWorld)
        {
            throw new System.NotImplementedException();
        }

        protected override string GetWorldName() => ECSConstants.MAIN_WORLD_NAME;
    }
}