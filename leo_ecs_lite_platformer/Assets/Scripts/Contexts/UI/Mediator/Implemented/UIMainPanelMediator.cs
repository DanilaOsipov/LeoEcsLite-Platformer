using Common;
using Contexts.Main.Command;
using Contexts.UI.Command;
using Contexts.UI.View.Implemented;

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
            var startSequence = new CommandSequence()
                .Add(new HideUIPanelCommand<UIMainPanelView>(_serviceLocator))
                .Add(new ShowUIPanelCommand<UILoadingPanelView>(_serviceLocator))
                .Add(new LoadLevelContextCommand(_serviceLocator))
                .Add(new HideUIPanelCommand<UILoadingPanelView>(_serviceLocator));
            startSequence.Execute();
        }
    }
}