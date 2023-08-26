using Contexts.Level.ECS.Listener;
using Leopotam.EcsLite;
using System;
using UnityEngine;

namespace Contexts.Level.ECS.Component
{
    [Serializable] public struct Position { public Vector3 Value; }
    [Serializable] public struct Speed { public float Value; }
    [Serializable] public struct InputMovement { }
    [Serializable] public struct PositionListener { public IPositionListener Value; }
    public struct Owner { public EcsPackedEntityWithWorld Value; }
    public struct PositionChangedMarker { }
}