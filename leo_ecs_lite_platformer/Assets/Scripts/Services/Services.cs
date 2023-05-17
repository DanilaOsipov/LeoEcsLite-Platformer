using System;
using System.Collections.Generic;
using UnityEngine;

namespace Services
{
    public static class Services
    {
        private static Dictionary<Type, IService> _services = new();

        public static void RegisterService<T>(IService service) where T : IService
        {
            if (_services.ContainsKey(typeof(T)))
            {
                _services[typeof(T)] = service;
                return;
            }
            
            _services.Add(typeof(T), service);
        }
        
        public static void UnregisterService<T>() where T : IService
        {
            if (!_services.ContainsKey(typeof(T)))
            {
                Debug.LogWarning($"Serivce with type {typeof(T)} is not registered");
                return;
            }
            
            _services.Remove(typeof(T));
        }

        public static T GetService<T>() where T : IService
        {
            return _services.ContainsKey(typeof(T)) ? (T)_services[typeof(T)] : default;
        }
    }
}