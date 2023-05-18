using ECS.Common;
using Leopotam.EcsLite;
using Services;

namespace ECS.Main
{
    public interface IInputService : IService
    {
        
    }

    public class UIRoot : ECSRoot
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

        protected override string GetWorldName() => ECSConstants.UI_WORLD_NAME;
    }
    
    public class MainRoot : ECSRoot
    {
        protected override void Awake()
        {
            RegisterServices();
            
            base.Awake();
            
            LoadUIWorld();
        }

        protected override EcsSystems CreateInitSystems(EcsWorld ecsWorld) => null;

        protected override EcsSystems CreateUpdateSystems(EcsWorld ecsWorld) => null;

        protected override EcsSystems CreateFixedUpdateSystems(EcsWorld ecsWorld) => null;

        protected override string GetWorldName() => ECSConstants.MAIN_WORLD_NAME;

        private void RegisterServices()
        {
            RegisterService<ISceneService>(new SceneManagerService());
        }

        private void LoadUIWorld()
        {
            var sceneService = GetService<ISceneService>();
            sceneService.OnSceneLoaded += OnUIWorldLoadedHandler;
            sceneService.LoadScene(ECSConstants.UI_WORLD_SCENE);
        }

        private void OnUIWorldLoadedHandler(string sceneName)
        {
            var sceneService = GetService<ISceneService>();
            sceneService.OnSceneLoaded -= OnUIWorldLoadedHandler;
        }
    }
}