using Leopotam.EcsLite;
using UnityEngine;

namespace ECS.Common
{
    public abstract class ECSRoot : MonoBehaviour
    {
        private EcsSystems _updateSystems;
        private EcsSystems _fixedUpdateSystems;
        
        private void Awake()
        {
            var ecsWorld = new EcsWorld();
            RegisterWorld(GetWorldName(), ecsWorld);
            
            var initSystems = CreateInitSystems(ecsWorld);
            _updateSystems = CreateUpdateSystems(ecsWorld);
            _fixedUpdateSystems = CreateFixedUpdateSystems(ecsWorld);
            
            initSystems?.Init();
            _updateSystems?.Init();
            _fixedUpdateSystems?.Init();
        }

        private void Update() => _updateSystems?.Run();

        private void FixedUpdate() => _fixedUpdateSystems?.Run();

        private void OnDestroy()
        {
            _updateSystems?.Destroy();
            _fixedUpdateSystems?.Destroy();
            
            var worldName = GetWorldName();
            UnregisterWorld(worldName);
            var ecsWorld = GetWorld(worldName);
            ecsWorld.Destroy();
        }

        protected abstract EcsSystems CreateInitSystems(EcsWorld ecsWorld);

        protected abstract EcsSystems CreateUpdateSystems(EcsWorld ecsWorld);

        protected abstract EcsSystems CreateFixedUpdateSystems(EcsWorld ecsWorld);

        protected abstract string GetWorldName();

        protected EcsWorld GetWorld(string worldName) => ECSWorlds.GetWorld(worldName);

        private void RegisterWorld(string worldName, EcsWorld ecsWorld) => ECSWorlds.RegisterWorld(worldName, ecsWorld);

        private void UnregisterWorld(string worldName) => ECSWorlds.UnregisterWorld(worldName);
    }
}