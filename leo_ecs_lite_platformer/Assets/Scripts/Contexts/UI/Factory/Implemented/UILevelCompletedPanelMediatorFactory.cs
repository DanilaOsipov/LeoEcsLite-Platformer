using Common;
using Contexts.UI.Mediator;
using Contexts.UI.Mediator.Implemented;
using Contexts.UI.View.Implemented;

namespace Contexts.UI.Factory.Implemented
{
    public class UILevelCompletedPanelMediatorFactory : UIMediatorConcreteFactory<UILevelCompletedPanelView>
    {
        public UILevelCompletedPanelMediatorFactory(IServiceLocator serviceLocator) : base(serviceLocator)
        {
        }

        protected override IUIPanelMediator CreateMediatorInternal(UILevelCompletedPanelView panelView, IServiceLocator serviceLocator)
        {
            return new UILevelCompletedPanelMediator(panelView, serviceLocator);
        }
    }
}