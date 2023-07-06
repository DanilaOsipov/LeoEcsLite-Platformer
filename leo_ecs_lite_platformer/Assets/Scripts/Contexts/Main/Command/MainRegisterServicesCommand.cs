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

            // TODO

            OnSucceed();
        }
    }
}