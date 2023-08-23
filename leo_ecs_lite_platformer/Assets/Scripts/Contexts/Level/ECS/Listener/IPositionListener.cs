using UnityEngine;

namespace Contexts.Level.ECS.Listener
{
    public interface IPositionListener
    {
        void UpdatePosition(Vector3 value);
    }
}