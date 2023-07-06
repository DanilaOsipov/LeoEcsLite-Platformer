using UnityEngine;

namespace Services
{
    public interface IAssetsService : IService
    {
        T LoadAsset<T>(string path) where T : Object;
    }
}