using Common;
using UnityEngine;

namespace Services.Implemented
{
    public class UnityInputService : IInputService
    {
        public Vector2 Axis => GetInputAxis();

        public bool JumpButtonDown => Input.GetButtonDown(ApplicationConstants.JUMP_BUTTON_NAME);

        private Vector2 GetInputAxis()
        {
            return new(
                x: Input.GetAxis(ApplicationConstants.HORIZONTAL_INPUT_AXIS_NAME),
                y: Input.GetAxis(ApplicationConstants.VERTICAL_INPUT_AXIS_NAME));
        }
    }
}