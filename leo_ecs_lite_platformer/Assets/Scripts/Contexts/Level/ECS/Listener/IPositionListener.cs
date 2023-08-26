using UnityEngine;

namespace Contexts.Level.ECS.Listener
{
    public interface IPositionListener
    {
        Vector3 CurrentPosition { get; }
        void UpdatePosition(Vector3 value);
    }
}