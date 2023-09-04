using Contexts.UI.Data;
using Contexts.UI.View;
using UnityEngine;

namespace Services
{
    public interface IUIService : IService
    {
        T ShowPanel<T>() where T : Object, IUIPanelView;
        void HidePanel<T>() where T : Object, IUIPanelView;

        TPanel ShowPanel<TPanel, TData>(TData data)
            where TPanel : Object, IUIPanelInitializableView<TData>
            where TData : IUIPanelData;
    }
}