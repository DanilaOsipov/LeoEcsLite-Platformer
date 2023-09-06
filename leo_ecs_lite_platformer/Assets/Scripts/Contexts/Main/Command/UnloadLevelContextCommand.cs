using Common;

namespace Contexts.Main.Command
{
    public class UnloadLevelContextCommand : UnloadContextCommand
    {
        public UnloadLevelContextCommand(IServiceLocator serviceLocator) : base(serviceLocator)
        {
        }

        protected override string GetContextSceneName() => ApplicationConstants.LEVEL_CONTEXT_SCENE_NAME;
    }
}