using Common;
using Contexts.UI.Mediator;
using Contexts.UI.View;
using System;
using System.Collections.Generic;

namespace Contexts.UI.Factory.Implemented
{
    public class UIMediatorCommonFactory : IUIPanelMediatorFactory
    {
        private readonly List<IUIPanelMediatorFactory> _factories = new();

        Type IUIPanelMediatorFactory.ViewType => typeof(IUIPanelView);

        public UIMediatorCommonFactory(IServiceLocator serviceLocator)
        {
            //_serviceLocator = serviceLocator;

            // TODO add factories
        }

        IUIPanelMediator IUIPanelMediatorFactory.CreateMediator(IUIPanelView panelView)
        {
            return GetFactory(panelView).CreateMediator(panelView);
        }

        private IUIPanelMediatorFactory GetFactory(IUIPanelView panelView)
        {
            return _factories.Find(e => e.ViewType == panelView.GetType());
        }
    }
}