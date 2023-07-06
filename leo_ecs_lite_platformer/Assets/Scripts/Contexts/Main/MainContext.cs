using Common;
using Contexts.Common;
using Contexts.Main.Command;
using UnityEngine;

namespace Contexts.Main
{
    public class MainContext : AplicationContext
    {
        [SerializeField] private Transform _uiRoot;
        //[SerializeField] private ; TODO loadingPanelView

        private void Awake()
        {
            var startupSequence = new CommandSequence()
                .Add(new MainRegisterServicesCommand(serviceLocator: this))
                .Add(new LoadUIContextCommand(serviceLocator: this));

            startupSequence.Execute();
        }
    }
}