using Contexts.UI.Data;

namespace Contexts.UI.View
{
    public interface IUIPanelInitializableView<T> : IUIPanelView where T : IUIPanelData
    {
        void Initialize(T data);
    }
}