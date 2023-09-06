using Common;
using Contexts.UI.View.Implemented;
using Services;
using System;

namespace Contexts.UI.Command
{
    public class DestroyStartupLoadingPanelCommand : ICommand
    {
        private readonly IServiceLocator _serviceLocator;

        public event Action OnSucceed = delegate { };
        public event Action OnFailed = delegate { };

        public DestroyStartupLoadingPanelCommand(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public void Execute()
        {
            var viewService = _serviceLocator.GetService<IViewService>();
            var panel = viewService.Find<UIStartupLoadingPanelView>();
            viewService.Destroy(panel.GameObject);
            OnSucceed();
        }
    }
}