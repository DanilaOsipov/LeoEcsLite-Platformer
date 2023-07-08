using Common;
using Services;
using System;
using Contexts.UI.View;

namespace Contexts.UI.Command
{
    public class ShowUIPanelCommand<T> : ICommand where T : UnityEngine.Object, IUIPanelView
    {
        private readonly IServiceLocator _serviceLocator;

        public event Action OnSucceed = delegate { };
        public event Action OnFailed = delegate { };

        public ShowUIPanelCommand(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public void Execute()
        {
            _serviceLocator.GetService<IUIService>().ShowPanel<T>();
            OnSucceed();
        }
    }
}