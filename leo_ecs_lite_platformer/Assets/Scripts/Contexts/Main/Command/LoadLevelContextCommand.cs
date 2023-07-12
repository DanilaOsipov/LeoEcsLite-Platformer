using Common;

namespace Contexts.Main.Command
{
    public class LoadLevelContextCommand : LoadContextCommand
    {
        public LoadLevelContextCommand(IServiceLocator serviceLocator) : base(serviceLocator)
        {
        }

        protected override string GetContextSceneName() => ApplicationConstants.LEVEL_CONTEXT_SCENE_NAME;
    }
}