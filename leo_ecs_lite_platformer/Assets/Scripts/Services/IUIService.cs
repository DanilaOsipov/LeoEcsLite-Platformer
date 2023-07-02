using Contexts.UI.Data;
using Contexts.UI.View;
using UnityEngine;

namespace Services
{
    public interface IUIService : IService
    {
        T ShowPanel<T>() where T : Object, IUIPanelView;
        T HidePanel<T>() where T : IUIPanelView;

        TPanel ShowPanel<TPanel, TData>(TData data)
            where TPanel : IUIPanelInitializableView<TData>
            where TData : IUIPanelData;
    }
}