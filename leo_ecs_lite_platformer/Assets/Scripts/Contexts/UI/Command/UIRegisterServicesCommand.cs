using Common;
using Services.Implemented;
using Services;
using System;
using Contexts.UI.Factory.Implemented;
using UnityEngine;

namespace Contexts.UI.Command
{
    public class UIRegisterServicesCommand : ICommand
    {
        private readonly IServiceLocator _serviceLocator;
        private readonly Transform _uiRoot;

        public UIRegisterServicesCommand(IServiceLocator serviceLocator, Transform uiRoot)
        {
            _serviceLocator = serviceLocator;
            _uiRoot = uiRoot;
        }

        public event Action OnSucceed = delegate { };
        public event Action OnFailed = delegate { };

        public void Execute()
        {
            var assetsService = _serviceLocator.GetService<IAssetsService>();
            var viewService = _serviceLocator.GetService<IViewService>();
            var mediatorFactory = new UIMediatorCommonFactory(_serviceLocator);

            _serviceLocator.RegisterService<IUIService>(new UIMediationService(
                assetsService,
                viewService,
                mediatorFactory,
                _uiRoot));

            OnSucceed();
        }
    }
}