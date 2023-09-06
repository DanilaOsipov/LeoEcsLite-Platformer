using System;

namespace Services
{
    public interface ISceneService : IService
    {
        void LoadScene(string sceneName);
        void UnloadScene(string sceneName);
        event Action<string> OnSceneLoaded;
        event Action<string> OnSceneUnloaded;
    }
}