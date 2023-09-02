using Contexts.Level.ECS.Component;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Common;
using Contexts.Level.ECS.Event;
using UnityEngine;

namespace Contexts.Level.ECS.System
{
    public class InputJumpSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<InputJump, ForceListener, JumpForce, Grounded>> _jumpFilter = default;
        private readonly EcsPoolInject<JumpForce> _forces = default;
        private readonly EcsPoolInject<ForceListener> _listeners = default;

        private readonly EcsFilterInject<Inc<JumpInputEvent>> _inputFilter = ApplicationConstants.ECS_EVENTS_WORLD_NAME;

        public void Run(IEcsSystems systems)
        {
            foreach (var inputEntity in _inputFilter.Value)
            {
                foreach (var jumpEntity in _jumpFilter.Value)
                {
                    var forceListener = _listeners.Value.Get(jumpEntity);
                    var jumpForce = _forces.Value.Get(jumpEntity);
                    forceListener.Value.AddForce(Vector3.up * jumpForce.Value, ForceMode.Impulse);
                }
            }
        }
    }
}