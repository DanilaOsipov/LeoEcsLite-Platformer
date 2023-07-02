using UnityEngine;

namespace Services
{
    public interface IAssetsService : IService
    {
        T[] LoadAssets<T>(string path) where T : Object;
        Object[] LoadAssets(string path);
        T LoadAsset<T>(string path) where T : Object;
        Object LoadAsset(string path);
    }
}