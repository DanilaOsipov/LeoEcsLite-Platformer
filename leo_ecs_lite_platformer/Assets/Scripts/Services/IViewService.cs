﻿using UnityEngine;
using Object = UnityEngine.Object;

namespace Services
{
    public interface IViewService : IService
    {
        T Instantiate<T>(T original, Transform parent) where T : Object;
        void Destroy<T>(T view) where T : Object;
        T Find<T>() where T : Object;
    }
}