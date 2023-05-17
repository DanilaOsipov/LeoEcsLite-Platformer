using Leopotam.EcsLite;
using Services;
using UnityEngine;

namespace ECS.Common
{
    public abstract class ECSRoot : MonoBehaviour
    {
        private EcsSystems _updateSystems;
        private EcsSystems _fixedUpdateSystems;

        protected virtual void Awake()
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
            var ecsWorld = GetWorld(worldName);
            UnregisterWorld(worldName);
            ecsWorld.Destroy();
        }

        protected abstract EcsSystems CreateInitSystems(EcsWorld ecsWorld);

        protected abstract EcsSystems CreateUpdateSystems(EcsWorld ecsWorld);

        protected abstract EcsSystems CreateFixedUpdateSystems(EcsWorld ecsWorld);

        protected void RegisterService<T>(IService service) where T : IService => Services.Services.RegisterService<T>(service);

        protected void UnregisterService<T>() where T : IService => Services.Services.UnregisterService<T>();

        protected T GetService<T>() where T : IService => Services.Services.GetService<T>();

        protected abstract string GetWorldName();

        protected EcsWorld GetWorld(string worldName) => ECSWorlds.GetWorld(worldName);

        private void RegisterWorld(string worldName, EcsWorld ecsWorld) => ECSWorlds.RegisterWorld(worldName, ecsWorld);

        private void UnregisterWorld(string worldName) => ECSWorlds.UnregisterWorld(worldName);
    }
}