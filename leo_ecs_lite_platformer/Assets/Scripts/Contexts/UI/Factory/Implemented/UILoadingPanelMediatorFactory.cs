using Common;
using Contexts.UI.Mediator;
using Contexts.UI.Mediator.Implemented;
using Contexts.UI.View.Implemented;

namespace Contexts.UI.Factory.Implemented
{
    public class UILoadingPanelMediatorFactory : UIMediatorConcreteFactory<UILoadingPanelView>
    {
        public UILoadingPanelMediatorFactory(IServiceLocator serviceLocator) : base(serviceLocator)
        {
        }

        protected override IUIPanelMediator CreateMediatorInternal(UILoadingPanelView panelView, IServiceLocator serviceLocator)
        {
            return new UILoadingPanelMediator(panelView, serviceLocator);
        }
    }
}