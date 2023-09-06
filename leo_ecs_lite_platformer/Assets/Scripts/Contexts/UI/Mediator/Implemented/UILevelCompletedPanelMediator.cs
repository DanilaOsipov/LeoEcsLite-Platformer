using Common;
using Contexts.Main.Command;
using Contexts.UI.Command;
using Contexts.UI.View.Implemented;

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
            var restartSequence = new CommandSequence()
                .Add(new HideUIPanelCommand<UILevelCompletedPanelView>(_serviceLocator))
                .Add(new ShowUIPanelCommand<UILoadingPanelView>(_serviceLocator))
                .Add(new UnloadLevelContextCommand(_serviceLocator))
                .Add(new LoadLevelContextCommand(_serviceLocator))
                .Add(new HideUIPanelCommand<UILoadingPanelView>(_serviceLocator));
            restartSequence.Execute();
        }

        private void OnExitButtonClickHandler()
        {
            var exitSequence = new CommandSequence()
                .Add(new HideUIPanelCommand<UILevelCompletedPanelView>(_serviceLocator))
                .Add(new ShowUIPanelCommand<UILoadingPanelView>(_serviceLocator))
                .Add(new UnloadLevelContextCommand(_serviceLocator))
                .Add(new HideUIPanelCommand<UILoadingPanelView>(_serviceLocator))
                .Add(new ShowUIPanelCommand<UIMainPanelView>(_serviceLocator));
            exitSequence.Execute();
        }
    }
}