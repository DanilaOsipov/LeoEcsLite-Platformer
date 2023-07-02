using Common;
using UnityEngine;

namespace Contexts.Common
{
    public abstract class AplicationContext : MonoBehaviour, IServiceLocator
    {
        T IServiceLocator.GetService<T>()
        {
            throw new System.NotImplementedException();
        }

        void IServiceLocator.RegisterService<T>(T service)
        {
            throw new System.NotImplementedException();
        }

        void IServiceLocator.UnregisterService<T>()
        {
            throw new System.NotImplementedException();
        }
    }
}