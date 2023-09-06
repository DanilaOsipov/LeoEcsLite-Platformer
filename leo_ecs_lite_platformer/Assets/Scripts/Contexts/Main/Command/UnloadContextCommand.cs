using Common;
using Services;
using System;

namespace Contexts.Main.Command
{
    public abstract class UnloadContextCommand : ICommand
    {
        private readonly IServiceLocator _serviceLocator;

        public event Action OnSucceed = delegate { };
        public event Action OnFailed = delegate { };

        protected UnloadContextCommand(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public void Execute()
        {
            var sceneService = GetSceneService();
            sceneService.OnSceneUnloaded += OnSceneUnloadedHandler;

            sceneService.UnloadScene(GetContextSceneName());
        }

        protected abstract string GetContextSceneName();

        private void OnSceneUnloadedHandler(string sceneName)
        {
            var sceneService = GetSceneService();
            sceneService.OnSceneUnloaded -= OnSceneUnloadedHandler;

            OnSucceed();
        }

        private ISceneService GetSceneService() => _serviceLocator.GetService<ISceneService>();
    }
}