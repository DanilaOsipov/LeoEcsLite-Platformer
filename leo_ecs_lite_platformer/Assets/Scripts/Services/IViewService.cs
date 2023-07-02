using UnityEngine;
using Object = UnityEngine.Object;

namespace Services
{
    public interface IViewService : IService
    {
        Object Instantiate(Object original, Transform parent);
    }
}