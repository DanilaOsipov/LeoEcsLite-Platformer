using UnityEngine;

namespace Contexts.Level.ECS.Listener
{
    public interface IForceListener
    {
        void AddForce(Vector3 force, ForceMode mode = ForceMode.Force);
    }
}