using Common;
using Contexts.UI.View;

namespace Contexts.UI.Mediator.Implemented
{
    public abstract class UIPanelMediator<T> : IUIPanelMediator where T : IUIPanelView
    {
        protected readonly IServiceLocator _serviceLocator;

        public IUIPanelView PanelView { get; }

        protected UIPanelMediator(T panelView, IServiceLocator serviceLocator)
        {
            PanelView = panelView;
            _serviceLocator = serviceLocator;
        }

        public void HidePanel() => PanelView.Hide();

        public void ShowPanel() => PanelView.Show();
    }
}