﻿using System.Linq;
using UnityEngine;

namespace Services.Implemented
{
    public class ResourcesService : IAssetsService
    {
        public T LoadAsset<T>(string path) where T : Object => Resources.LoadAll<T>(path).FirstOrDefault();
    }
}