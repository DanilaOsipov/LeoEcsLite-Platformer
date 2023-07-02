using Common;
using Contexts.Common;
using UnityEngine;

namespace Contexts.Main
{
    public class MainContext : AplicationContext
    {
        [SerializeField] private Transform _uiRoot;
        //[SerializeField] private ; TODO loadingPanelView

        private void Awake()
        {
            ICommand registerServicesCommand = new RegisterServicesCommand(serviceLocator: this);
            registerServicesCommand.Execute();
        }
    }
}