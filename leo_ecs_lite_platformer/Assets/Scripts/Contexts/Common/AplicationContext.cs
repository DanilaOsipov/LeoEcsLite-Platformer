using Common;
using LeopotamGroup.Globals;
using Services;
using UnityEngine;

namespace Contexts.Common
{
    public abstract class AplicationContext : MonoBehaviour, IServiceLocator
    {
        public T GetService<T>() where T : class, IService => Service<T>.Get();

        public void RegisterService<T>(T service) where T : class, IService => Service<T>.Set(service);

        public void UnregisterService<T>() where T : class, IService => Service<T>.Set(null);
    }
}