using UnityEngine;

namespace Contexts.Level.ECS.Listener.Implemented
{
    [RequireComponent(typeof(Rigidbody))]
    public class RigidbodyPositionListener : MonoBehaviour, IPositionListener
    {
        private Rigidbody _rigidbody;

        public Vector3 CurrentPosition => _rigidbody.position;

        private void Awake() => _rigidbody = GetComponent<Rigidbody>();

        public void UpdatePosition(Vector3 value) => _rigidbody.MovePosition(value);
    }
}