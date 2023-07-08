using Common;
using Contexts.Common;
using Contexts.UI.Command;
using UnityEngine;

namespace Contexts.UI
{
    public class UIContext : AplicationContext
    {
        [SerializeField] private Transform _uiRoot;

        private void Awake()
        {
            var startupSequence = new CommandSequence()
               .Add(new UIRegisterServicesCommand(serviceLocator: this, _uiRoot));

            startupSequence.Execute();
        }
    }
}