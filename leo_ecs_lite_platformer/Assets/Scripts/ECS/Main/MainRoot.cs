using ECS.Common;
using Leopotam.EcsLite;
using Services;

namespace ECS.Main
{
    public class MainRoot : ECSRoot
    {
        protected override void Awake()
        {
            RegisterServices();
            
            base.Awake();
            
            LoadInputWorld();
        }

        protected override EcsSystems CreateInitSystems(EcsWorld ecsWorld) => null;

        protected override EcsSystems CreateUpdateSystems(EcsWorld ecsWorld) => null;

        protected override EcsSystems CreateFixedUpdateSystems(EcsWorld ecsWorld) => null;

        protected override string GetWorldName() => ECSConstants.MAIN_WORLD_NAME;

        private void RegisterServices()
        {
            RegisterService<ISceneService>(new SceneManagerService());
        }

        private void LoadInputWorld()
        {
            var sceneService = GetService<ISceneService>();
            sceneService.OnSceneLoaded += OnInputWorldLoadedHandler;
            sceneService.LoadScene(ECSConstants.INPUT_WORLD_SCENE);
        }

        private void OnInputWorldLoadedHandler(string sceneName)
        {
            var sceneService = GetService<ISceneService>();
            sceneService.OnSceneLoaded -= OnInputWorldLoadedHandler;
            
        }
    }
}