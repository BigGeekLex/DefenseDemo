using UnityEngine;

namespace Movement
{
    sealed class InputDirectionMovementSetter : DirectionMovementSetterBase
    {
        private void Update()
        {
            SetDirectionToMovable();
        }
        protected override Vector2 GetDirection()
        {
            float vertical = Input.GetAxis(InputConstants.VerticalAxisName);
            float horizontal = Input.GetAxis(InputConstants.HorizontalAxisName);
            return new Vector2( horizontal, vertical);
        }
    }   
}