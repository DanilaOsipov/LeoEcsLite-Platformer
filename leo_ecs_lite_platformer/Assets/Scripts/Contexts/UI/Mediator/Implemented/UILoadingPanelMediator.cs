using Common;
using Contexts.UI.View.Implemented;

namespace Contexts.UI.Mediator.Implemented
{
    public class UILoadingPanelMediator : UIPanelMediator<UILoadingPanelView>
    {
        public UILoadingPanelMediator(UILoadingPanelView panelView, IServiceLocator serviceLocator) : base(panelView, serviceLocator)
        {
        }
    }
}