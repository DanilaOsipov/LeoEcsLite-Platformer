using Contexts.UI.Data;

namespace Contexts.UI.Mediator
{
    public interface IUIPanelInitializableMediator<T> : IUIPanelMediator where T : IUIPanelData
    {
        void Initialize(T data);
    }
}