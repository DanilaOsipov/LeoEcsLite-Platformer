using Common;
using Contexts.Common;
using Contexts.Main.Command;

namespace Contexts.Main
{
    public class MainContext : AplicationContext
    {
        private void Awake()
        {
            var startupSequence = new CommandSequence()
                .Add(new MainRegisterServicesCommand(serviceLocator: this))
                .Add(new LoadUIContextCommand(serviceLocator: this));

            startupSequence.Execute();
        }
    }
}