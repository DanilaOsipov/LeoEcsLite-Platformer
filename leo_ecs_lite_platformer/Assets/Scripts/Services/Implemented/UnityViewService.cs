using UnityEngine;

namespace Services.Implemented
{
    public class UnityViewService : IViewService
    {
        public T Instantiate<T>(T original, Transform parent) where T : Object => Object.Instantiate(original, parent);
    }
}