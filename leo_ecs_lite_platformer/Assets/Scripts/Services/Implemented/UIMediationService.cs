using Common;
using Contexts.UI.Factory;
using Contexts.UI.Mediator;
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

        T IUIService.HidePanel<T>()
        {
            throw new System.NotImplementedException();
        }

        T IUIService.ShowPanel<T>()
        {
            var panelPrefab = _assetsService.LoadAsset<T>(ApplicationConstants.UI_PANELS_PATH);
            var panelView = _viewService.Instantiate(panelPrefab, _uiRoot) as T;
            var panelMediator = _mediatorFactory.CreateMediator(panelView);
            _instantiatedMediators.Add(panelMediator);
            panelMediator.ShowPanel();
            return panelView;
        }

        TPanel IUIService.ShowPanel<TPanel, TData>(TData data)
        {
            throw new System.NotImplementedException();
        }
    }
}