using Common;

namespace Contexts.Main.Command
{
    public class LoadUIContextCommand : LoadContextCommand
    {
        public LoadUIContextCommand(IServiceLocator serviceLocator) : base(serviceLocator)
        {
        }

        protected override string GetContextSceneName() => ApplicationConstants.UI_CONTEXT_SCENE_NAME;
    }
}