using UnityEngine;

namespace Movement
{
    [RequireComponent(typeof(MovementBase))]
    public abstract class DirectionMovementSetterBase : MonoBehaviour
    {
        protected MovementBase movementBase;
        private void Awake()
        {
            movementBase = GetComponent<MovementBase>();
        }
        protected virtual void SetDirectionToMovable()
        {
            movementBase.SetDirection(GetDirection());
        }
        protected abstract Vector2 GetDirection();
    }   
}