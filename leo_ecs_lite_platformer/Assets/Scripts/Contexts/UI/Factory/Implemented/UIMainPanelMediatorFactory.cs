using Common;
using Contexts.UI.Mediator;
using Contexts.UI.Mediator.Implemented;
using Contexts.UI.View.Implemented;

namespace Contexts.UI.Factory.Implemented
{
    public class UIMainPanelMediatorFactory : UIMediatorConcreteFactory<UIMainPanelView>
    {
        public UIMainPanelMediatorFactory(IServiceLocator serviceLocator) : base(serviceLocator)
        {
        }

        protected override IUIPanelMediator CreateMediatorInternal(UIMainPanelView panelView, IServiceLocator serviceLocator)
        {
            return new UIMainPanelMediator(panelView, serviceLocator);
        }
    }
}