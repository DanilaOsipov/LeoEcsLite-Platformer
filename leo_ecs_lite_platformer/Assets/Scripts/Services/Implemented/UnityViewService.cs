using UnityEngine;

namespace Services.Implemented
{
    public class UnityViewService : IViewService
    {
        public void Destroy<T>(T view) where T : Object => Object.Destroy(view);

        public T Find<T>() where T : Object => Object.FindObjectOfType<T>();

        public T Instantiate<T>(T original, Transform parent) where T : Object => Object.Instantiate(original, parent);
    }
}