using System;
using UnityEngine.SceneManagement;

namespace Services.Implemented
{
    public class SceneManagerService : ISceneService
    {
        public event Action<string> OnSceneLoaded = delegate { };
        public event Action<string> OnSceneUnloaded = delegate { };

        public void LoadScene(string sceneName)
        {
            var loadSceneAsync = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            loadSceneAsync.completed += delegate { OnSceneLoaded(sceneName); };
        }

        public void UnloadScene(string sceneName)
        {
            var unloadSceneAsync = SceneManager.UnloadSceneAsync(sceneName);
            unloadSceneAsync.completed += delegate { OnSceneUnloaded(sceneName); };
        }
    }
}