using System;
using UnityEngine;

namespace Contexts.Level.ECS.Component
{
    [Serializable] public struct Position { public Vector3 Value; }
    [Serializable] public struct Speed { public float Value; }
    [Serializable] public struct InputMovement { }
    public struct PositionChangedMarker { }
}