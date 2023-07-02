using Common;
using Contexts.UI.Mediator;
using Contexts.UI.View;
using System;

namespace Contexts.UI.Factory.Implemented
{
    public abstract class UIMediatorConcreteFactory<T> : IUIPanelMediatorFactory where T : IUIPanelView
    {
        private readonly IServiceLocator _serviceLocator;

        Type IUIPanelMediatorFactory.ViewType => typeof(T);

        protected UIMediatorConcreteFactory(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        IUIPanelMediator IUIPanelMediatorFactory.CreateMediator(IUIPanelView panelView)
        {
            return CreateMediatorInternal((T)panelView, _serviceLocator);
        }

        protected abstract IUIPanelMediator CreateMediatorInternal(T panelView, IServiceLocator serviceLocator);
    }
}