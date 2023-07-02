using Services;

namespace Common
{
    public interface IServiceLocator
    {
        void RegisterService<T>(T service) where T : IService;
        void UnregisterService<T>() where T : IService;
        T GetService<T>() where T : IService;
    }
}