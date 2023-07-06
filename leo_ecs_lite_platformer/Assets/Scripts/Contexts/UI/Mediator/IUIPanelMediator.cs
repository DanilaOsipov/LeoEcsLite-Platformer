using Contexts.UI.View;

namespace Contexts.UI.Mediator
{
    public interface IUIPanelMediator
    {
        IUIPanelView PanelView { get; }
        void ShowPanel();
        void HidePanel();
    }
}