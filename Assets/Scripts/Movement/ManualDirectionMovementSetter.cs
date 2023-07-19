using UnityEngine;

namespace Movement
{
    sealed class ManualDirectionMovementSetter : DirectionMovementSetterBase
    {
        [SerializeField] 
        private Vector2 direction;
        private void Start()
        {
            SetDirectionToMovable();
        }
        protected override Vector2 GetDirection()
        {
            return direction.normalized;
        }
    }   
}