using Services;

namespace Common
{
    public interface IServiceLocator
    {
        void RegisterService<T>(T service) where T : class, IService;
        void UnregisterService<T>() where T : class, IService;
        T GetService<T>() where T : class, IService;
    }
}