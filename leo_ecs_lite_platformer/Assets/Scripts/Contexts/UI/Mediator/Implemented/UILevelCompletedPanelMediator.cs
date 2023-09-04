using Common;
using Contexts.UI.View.Implemented;

namespace Contexts.UI.Mediator.Implemented
{
    public class UILevelCompletedPanelMediator : UIPanelMediator<UILevelCompletedPanelView>
    {
        public UILevelCompletedPanelMediator(UILevelCompletedPanelView panelView, IServiceLocator serviceLocator) : base(panelView, serviceLocator)
        {
        }
    }
}