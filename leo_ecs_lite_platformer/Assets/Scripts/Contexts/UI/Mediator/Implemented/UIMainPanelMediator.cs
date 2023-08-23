using Common;
using Contexts.Main.Command;
using Contexts.UI.View.Implemented;
using Services;

namespace Contexts.UI.Mediator.Implemented
{
    public class UIMainPanelMediator : UIPanelMediator<UIMainPanelView>
    {
        public UIMainPanelMediator(UIMainPanelView panelView, IServiceLocator serviceLocator) : base(panelView, serviceLocator)
        {
            panelView.OnStartButtonClick += OnStartButtonClickHandler;
        }

        private void OnStartButtonClickHandler()
        {
            var loadLevelContextCommand = new LoadLevelContextCommand(_serviceLocator);
            loadLevelContextCommand.OnSucceed += OnLevelContextLoadedHandler;
            loadLevelContextCommand.Execute();
        }

        private void OnLevelContextLoadedHandler()
        {
            var uiService = _serviceLocator.GetService<IUIService>();
            uiService.HidePanel<UIMainPanelView>();
        }
    }
}