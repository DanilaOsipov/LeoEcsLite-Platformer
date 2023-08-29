using UnityEngine;

namespace Contexts.Level.ECS.Listener.Implemented
{
    [RequireComponent(typeof(Rigidbody))]
    public class RigidbodyListener : MonoBehaviour, IPositionListener, IForceListener
    {
        private Rigidbody _rigidbody;

        public Vector3 CurrentPosition => _rigidbody.position;

        private void Awake() => _rigidbody = GetComponent<Rigidbody>();

        public void UpdatePosition(Vector3 value) => _rigidbody.MovePosition(value);

        public void AddForce(Vector3 force, ForceMode mode = ForceMode.Force)
        {
            _rigidbody.AddForce(force, ForceMode.Impulse);
        }
    }
}