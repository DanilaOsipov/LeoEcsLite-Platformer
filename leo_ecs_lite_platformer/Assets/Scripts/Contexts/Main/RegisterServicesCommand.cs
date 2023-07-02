using Common;
using Services;
using Services.Implemented;

namespace Contexts.Main
{
    public class RegisterServicesCommand : ICommand
    {
        private IServiceLocator _serviceLocator;

        public RegisterServicesCommand(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        void ICommand.Execute()
        {
            _serviceLocator.RegisterService<ISceneService>(new SceneManagerService());
            _serviceLocator.RegisterService<IInputService>(new UnityInputService());

            // TODO
        }
    }
}