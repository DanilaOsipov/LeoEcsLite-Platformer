using Common;
using Services;
using System;

namespace Contexts.Main.Command
{
    public abstract class LoadContextCommand : ICommand
    {
        private readonly IServiceLocator _serviceLocator;

        public event Action OnSucceed = delegate { };
        public event Action OnFailed = delegate { };

        protected LoadContextCommand(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public void Execute()
        {
            var sceneService = GetSceneService();
            sceneService.OnSceneLoaded += OnSceneLoadedHandler;

            sceneService.LoadScene(GetContextSceneName());
        }

        protected abstract string GetContextSceneName();

        private void OnSceneLoadedHandler(string sceneName)
        {
            var sceneService = GetSceneService();
            sceneService.OnSceneLoaded -= OnSceneLoadedHandler;

            OnSucceed();
        }

        private ISceneService GetSceneService() => _serviceLocator.GetService<ISceneService>();
    }
}