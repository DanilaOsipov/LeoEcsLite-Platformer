using System;

namespace Services
{
    public interface ISceneService : IService
    {
        public void LoadScene(string sceneName);
        event Action<string> OnSceneLoaded;
    }
}