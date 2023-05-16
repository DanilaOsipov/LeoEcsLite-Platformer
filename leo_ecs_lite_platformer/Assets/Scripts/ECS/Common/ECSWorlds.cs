using System.Collections.Generic;
using Leopotam.EcsLite;
using UnityEngine;

namespace ECS.Common
{
    public static class ECSWorlds
    {
        private static Dictionary<string, EcsWorld> _ecsWorlds = new();

        public static void RegisterWorld(string worldName, EcsWorld ecsWorld)
        {
            if (_ecsWorlds.ContainsKey(worldName))
            {
                Debug.LogWarning($"World {worldName} already registered");
                return;
            }
            
            _ecsWorlds.Add(worldName, ecsWorld);
        }
        
        public static void UnregisterWorld(string worldName)
        {
            if (!_ecsWorlds.ContainsKey(worldName))
            {
                Debug.LogWarning($"World {worldName} is not registered");
                return;
            }

            _ecsWorlds.Remove(worldName);
        }

        public static EcsWorld GetWorld(string worldName)
        {
            return _ecsWorlds.ContainsKey(worldName) ? _ecsWorlds[worldName] : null;
        }
    }
}