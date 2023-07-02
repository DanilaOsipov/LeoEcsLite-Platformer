using Contexts.UI.Mediator;
using Contexts.UI.View;
using System;

namespace Contexts.UI.Factory
{
    public interface IUIPanelMediatorFactory
    {
        Type ViewType { get; }
        IUIPanelMediator CreateMediator(IUIPanelView panelView);
    }
}