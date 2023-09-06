using Common;
using Contexts.Main.Command;
using Contexts.UI.View.Implemented;
using Services;

namespace Contexts.UI.Mediator.Implemented
{
    public class UILevelCompletedPanelMediator : UIPanelMediator<UILevelCompletedPanelView>
    {
        public UILevelCompletedPanelMediator(UILevelCompletedPanelView panelView, IServiceLocator serviceLocator) : base(panelView, serviceLocator)
        {
            panelView.OnExitButtonClick += OnExitButtonClickHandler;
            panelView.OnRestartButtonClick += OnRestartButtonClickHandler;
        }

        private void OnRestartButtonClickHandler()
        {
            var uiService = _serviceLocator.GetService<IUIService>();
            uiService.HidePanel<UILevelCompletedPanelView>();

            var restartSequence = new CommandSequence()
                .Add(new UnloadLevelContextCommand(_serviceLocator))
                .Add(new LoadLevelContextCommand(_serviceLocator));
            restartSequence.Execute();
        }

        private void OnExitButtonClickHandler()
        {
            var uiService = _serviceLocator.GetService<IUIService>();
            uiService.HidePanel<UILevelCompletedPanelView>();

            var unloadLevelContextCommand = new UnloadLevelContextCommand(_serviceLocator);
            unloadLevelContextCommand.OnSucceed += OnLevelContextUnloadedHandler;
            unloadLevelContextCommand.Execute();
        }

        private void OnLevelContextUnloadedHandler()
        {
            var uiService = _serviceLocator.GetService<IUIService>();
            uiService.ShowPanel<UIMainPanelView>();
        }
    }
}