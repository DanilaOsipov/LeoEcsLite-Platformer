using Common;
using Services;
using Services.Implemented;
using System;

namespace Contexts.Main.Command
{
    public class MainRegisterServicesCommand : ICommand
    {
        private readonly IServiceLocator _serviceLocator;

        public event Action OnSucceed = delegate { };
        public event Action OnFailed = delegate { };

        public MainRegisterServicesCommand(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public void Execute()
        {
            _serviceLocator.RegisterService<ISceneService>(new SceneManagerService());
            _serviceLocator.RegisterService<IInputService>(new UnityInputService());
            _serviceLocator.RegisterService<IAssetsService>(new ResourcesService());
            _serviceLocator.RegisterService<IViewService>(new UnityViewService());
            _serviceLocator.RegisterService<ITimeService>(new UnityTimeService());

            OnSucceed();
        }
    }
}