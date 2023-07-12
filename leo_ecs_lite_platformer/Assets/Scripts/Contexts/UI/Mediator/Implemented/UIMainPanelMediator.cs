using Common;
using Contexts.Main.Command;
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
            var loadLevelContextCommand = new LoadLevelContextCommand(_serviceLocator);
            loadLevelContextCommand.Execute();
        }
    }
}