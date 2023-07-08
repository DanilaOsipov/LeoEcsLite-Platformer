using Common;
using Contexts.UI.Data;
using Contexts.UI.Factory;
using Contexts.UI.Mediator;
using Contexts.UI.View;
using System.Collections.Generic;
using UnityEngine;

namespace Services.Implemented
{
    public class UIMediationService : IUIService
    {
        private readonly IAssetsService _assetsService;
        private readonly IViewService _viewService;
        private readonly IUIPanelMediatorFactory _mediatorFactory;

        private readonly Transform _uiRoot;

        private readonly List<IUIPanelMediator> _instantiatedMediators = new();

        public UIMediationService(
            IAssetsService assetsService,
            IViewService viewService,
            IUIPanelMediatorFactory mediatorFactory,
            Transform uiRoot)
        {
            _assetsService = assetsService;
            _viewService = viewService;
            _mediatorFactory = mediatorFactory;
            _uiRoot = uiRoot;
        }

        public T HidePanel<T>() where T : Object, IUIPanelView
        {
            var panelMediator = _instantiatedMediators.Find(e => e.PanelView.GetType() == typeof(T));
            _instantiatedMediators.Remove(panelMediator);
            panelMediator.HidePanel();
            return (T)panelMediator.PanelView;
        }

        public T ShowPanel<T>() where T : Object, IUIPanelView
        {
            var panelPrefab = _assetsService.LoadAsset<T>(ApplicationConstants.UI_PANELS_PATH);
            var panelView = _viewService.Instantiate(panelPrefab, _uiRoot);
            var panelMediator = _mediatorFactory.CreateMediator(panelView);
            _instantiatedMediators.Add(panelMediator);
            panelMediator.ShowPanel();
            return panelView;
        }

        public TPanel ShowPanel<TPanel, TData>(TData data)
            where TPanel : Object, IUIPanelInitializableView<TData>
            where TData : IUIPanelData
        {
            var panelPrefab = _assetsService.LoadAsset<TPanel>(ApplicationConstants.UI_PANELS_PATH);
            var panelView = _viewService.Instantiate(panelPrefab, _uiRoot);
            var panelMediator = _mediatorFactory.CreateMediator(panelView);
            _instantiatedMediators.Add(panelMediator);
            var initializableMediator = panelMediator as IUIPanelInitializableMediator<TData>;
            initializableMediator.Initialize(data);
            initializableMediator.ShowPanel();
            return panelView;
        }
    }
}